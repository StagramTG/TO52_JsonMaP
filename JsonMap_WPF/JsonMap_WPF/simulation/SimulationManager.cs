using System;
using System.Net.Sockets;
using System.Threading;

using JsonMap.Data;

namespace JsonMap.Simulation
{
    public static class SimulationManager
    {
        /** Episode related */
        public static Episode CurrentEpisode { get; set; }

        /** Data to send through socket */
        public static Object Locker = new Object();
        public static String DataToSend { get; set; }
        public static bool NewDataExists { get; set; } = false;

        /** Simulation global stuffs */
        public static bool SimulationShouldRun { get; set; } = false;
        public static bool SimulationShouldPause { get; set; } = false;

        /** Communication related */
        public static String HostAdress { get; set; } = "127.0.0.1";
        public static String HostPort { get; set; } = "6666";
        public static Socket ComSocket { get; set; }

        /** Worker Threads instance */
        private static Thread SimulationThread;
        private static Thread CommunicationThread;

        /** Time manager */
        private static TimeManager timeManager;

        /// <summary>
        /// Launch the simulation by starting Workers thread
        /// </summary>
        public static void Launch()
        {
            SimulationThread = new Thread(Workers.SimulationWorker);
            CommunicationThread = new Thread(Workers.CommunicationWorker);

            timeManager = TimeManager.Instance;

            SimulationThread.Start();
            CommunicationThread.Start();
        }

        /// <summary>
        /// Block thread, pause the simulation in current state
        /// </summary>
        public static void Pause()
        {
            SimulationShouldPause = true;
        }

        /// <summary>
        /// Unblock thread
        /// </summary>
        public static void Unpause()
        {
            SimulationShouldPause = false;
        }

        /// <summary>
        /// Stop simulation thread
        /// </summary>
        public static void Stop()
        {
            /** Stop simulation and wait worker thread to join */
            SimulationShouldRun = false;

            SimulationThread.Join();
            CommunicationThread.Join();
        }
    }
}
