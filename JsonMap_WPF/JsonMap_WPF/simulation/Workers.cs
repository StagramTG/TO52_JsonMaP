using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace JsonMap.Simulation
{
    public static class Workers
    {
        /** Time between each line processing, Simulation time step isn't influenced */
        public static float ProcessingTimeStep { get; set; } = 1f;
        /** Time between each physics recalculation of forces apply  to rigid body, Processing time step isn't influenced */
        public static float SimulationTimeStep { get; set; } = 1f / 30f;

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

            while(SimulationManager.SimulationShouldRun)
            {
                /** Check if simulation is in pause state */
                if (SimulationManager.SimulationShouldPause)
                {
                    SimulationManager.PauseEvent.WaitOne();
                }

                /** Process simulation for next line */
                if (elapsedTimeProcessing >= ProcessingTimeStep)
                {
                    elapsedTimeProcessing = 0f;

                    /** Set next action as current action */
                    currentAction = SimulationManager.CurrentEpisode.Actions[SimulationManager.CurrentActionIndex];
                    SimulationManager.CurrentActionIndex++;

                    /** Update relations */
                    Console.WriteLine("Process RELATIONS !!!!");
                    SimulationManager.environment.UpdateAgentsRelations(currentAction);
                }

                /** Process physic simulation for current line */
                if (elapsedTimeSimulation >= SimulationTimeStep)
                {
                    Console.WriteLine("SIM TIME: " + elapsedTimeSimulation);

                    if (SimulationManager.SimulationShouldRun)
                    {
                        /** Do physics calculations */
                        SimulationManager.environment.UpdateAgents();

                        /** Launch communication task */
                        var t = Task.Run(async () => await SendData());
                        t.Wait();

                        Console.WriteLine("End task wait !!!!");
                        
                        elapsedTimeSimulation = 0f;
                    }
                }

                /** Update elapsed times */
                TimeManager.Instance.Update();
                float elapsedTime = TimeManager.Instance.DeltaTime;
                elapsedTimeProcessing += elapsedTime;
                elapsedTimeSimulation += elapsedTime;
            }

            Console.WriteLine("Simulation thread stop");
        }

        /**
         * Asynchronous communication task
         */
        static async Task SendData()
        {
            Console.WriteLine("SendData !");

            /** Send stuff through socket */
            NetworkStream stream = SimulationManager.ComSocket.GetStream();
            byte[] toSend = System.Text.Encoding.ASCII.GetBytes(
                Messages.CreateCharacterAgentMessage(SimulationManager.environment.GetCharacterAgentsData())
            );
            stream.Write(toSend, 0, toSend.Length);
        }
    }
}
