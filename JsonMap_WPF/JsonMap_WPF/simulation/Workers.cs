using System;
using System.Threading;

namespace JsonMap.Simulation
{
    public static class Workers
    {
        /** Time between each line processing, Simulation time step isn't influenced */
        public static float ProcessingTimeStep { get; set; }
        /** Time between each physics recalculation of forces apply  to rigid body, Processing time step isn't influenced */
        public static float SimulationTimeStep { get; set; }

        /**
         * Method that runs in simulation Thread.
         * Runs multiagents system to calculate physical behaviors
         * based on interactions extract from episode's script.
         */
        public static void SimulationWorker()
        {
            float elapsedTimeProcessing = 0f;
            float elapsedTimeSimulation = 0f;

            Console.WriteLine("Simulation thread start");

            TimeManager.Instance.Update();
            while(SimulationManager.SimulationShouldRun)
            {
                /** Process simulation for next line */
                if(elapsedTimeProcessing >= ProcessingTimeStep)
                {
                    elapsedTimeProcessing = 0f;
                }

                /** Process physic simulation for current line */
                if(elapsedTimeSimulation >= SimulationTimeStep)
                {
                    elapsedTimeSimulation = 0f;
                }

                Thread.Sleep(500);
                Console.WriteLine("Simulation thread run");

                /** Update elapsed times */
                float elapsedTime = TimeManager.Instance.DeltaTime;
                elapsedTimeProcessing += elapsedTime;
                elapsedTimeSimulation += elapsedTime;
                TimeManager.Instance.Update();
            }

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
                Thread.Sleep(500);
                Console.WriteLine("Communication thread run");
            }

            Console.WriteLine("Communication thread stop");
        }
    }
}
