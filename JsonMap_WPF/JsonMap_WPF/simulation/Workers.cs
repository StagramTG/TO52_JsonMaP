using System;
using System.Net.Sockets;
using System.Threading;

namespace JsonMap.Simulation
{
    public static class Workers
    {
        /** Time between each line processing, Simulation time step isn't influenced */
        public static float ProcessingTimeStep { get; set; } = 2f;
        /** Time between each physics recalculation of forces apply  to rigid body, Processing time step isn't influenced */
        public static float SimulationTimeStep { get; set; } = 1f / 60f;

        /**
         * Method that runs in simulation Thread.
         * Runs multiagents system to calculate physical behaviors
         * based on interactions extract from episode's script.
         */
        public static void SimulationWorker()
        {
            float elapsedTimeProcessing = 0f;
            float elapsedTimeSimulation = 0f;
            Data.Action currentAction = SimulationManager.CurrentEpisode.Actions[SimulationManager.CurrentActionIndex];
            SimulationManager.CurrentActionIndex++;

            Console.WriteLine("Simulation thread start");

            TimeManager.Instance.Update();

            while(SimulationManager.SimulationShouldRun)
            {
                /** Check if simulation is in pause state */
                if(SimulationManager.SimulationShouldPause)
                {
                    Console.WriteLine("Simulation pause");
                    SimulationManager.PauseEvent.WaitOne();
                    Console.WriteLine("Simulation unpause");
                }

                /** Process simulation for next line */
                if(elapsedTimeProcessing >= ProcessingTimeStep)
                {
                    elapsedTimeProcessing = 0f;

                    /** Set next action as current action */
                    currentAction = SimulationManager.CurrentEpisode.Actions[SimulationManager.CurrentActionIndex];
                    SimulationManager.CurrentActionIndex++;
                }

                /** Process physic simulation for current line */
                if(elapsedTimeSimulation >= SimulationTimeStep)
                {
                    elapsedTimeSimulation = 0f;
                    SimulationManager.ComSyncEvent.WaitOne();

                    /** Do physics calculations */
                    Console.WriteLine("Calculating sim...");
                    foreach(var agent in SimulationManager.AgsManager.Agents)
                    {
                        Agent.CharacterAgent.Behaviors behavior;

                        /** Actor of current action */
                        if(currentAction.CharactersId.Contains(agent.Value.CharacterData.Id))
                        {
                            behavior = Agent.CharacterAgent.Behaviors.ACTIVE;
                        }
                        /** Target of current action */
                        else if(currentAction.TargetsId.Contains(agent.Value.CharacterData.Id))
                        {
                            behavior = Agent.CharacterAgent.Behaviors.PASSIVE;
                        }
                        /** Don't appear in current action */
                        else
                        {
                            behavior = Agent.CharacterAgent.Behaviors.NOT_INVOLVED;
                        }

                        agent.Value.Update(currentAction, behavior);
                    }

                    SimulationManager.SimSyncEvent.Set();
                    SimulationManager.ComSyncEvent.Reset();
                }

                Thread.Sleep(500);

                /** Update elapsed times */
                float elapsedTime = TimeManager.Instance.DeltaTime;
                elapsedTimeProcessing += elapsedTime;
                elapsedTimeSimulation += elapsedTime;
                TimeManager.Instance.Update();
            }

            SimulationManager.SimSyncEvent.Set();

            Console.WriteLine("Simulation thread stop");
        }

        /**
         * Method that runs in communication Thread.
         * Send calculated data to render application through Socket.
         */
        public static void CommunicationWorker()
        {
            Console.WriteLine("Communication thread start");

            while (SimulationManager.SimulationShouldRun)
            {
                if (SimulationManager.SimulationShouldPause)
                {
                    Console.WriteLine("Communication pause");
                    SimulationManager.PauseEvent.WaitOne();
                    Console.WriteLine("Communication unpause");
                }

                SimulationManager.SimSyncEvent.WaitOne();

                /** Send stuff through socket */
                Console.WriteLine("Communication send data...");
                NetworkStream stream = SimulationManager.ComSocket.GetStream();
                byte[] toSend = System.Text.Encoding.ASCII.GetBytes("Update communication thread !");
                stream.Write(toSend, 0, toSend.Length);

                SimulationManager.ComSyncEvent.Set();
                SimulationManager.SimSyncEvent.Reset();
            }
            
            Console.WriteLine("Communication thread stop");
        }
    }
}
