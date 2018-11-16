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
            Console.WriteLine("Simulation thread start");

            while(SimulationManager.SimulationShouldRun)
            {
                Thread.Sleep(500);
                Console.WriteLine("Simulation thread run");
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
