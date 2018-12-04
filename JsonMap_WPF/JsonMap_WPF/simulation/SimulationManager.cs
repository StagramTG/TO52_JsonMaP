using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

using JsonMap.Data;

namespace JsonMap.Simulation
{
    public static class SimulationManager
    {
        /** Episode related */
        public static Episode CurrentEpisode           { get; set; }

        /** Simulation global stuffs */
        public static bool SimulationShouldRun         { get; set; } = false;
        public static bool SimulationShouldPause       { get; set; } = false;

        private static int currentActionLine = 0;
        public static int CurrentActionIndex
        {
            get { return currentActionLine; }
            set
            {
                if(currentActionLine != value)
                {
                    currentActionLine = value;
                    CurrentProcessedLineChange(null, null);
                }
            }
        }

        public static ManualResetEvent PauseEvent      { get; private set; }
        public static ManualResetEvent SimSyncEvent    { get; private set; }
        public static ManualResetEvent ComSyncEvent    { get; private set; }
        public static AgentsManager AgsManager      { get; private set; }

        /** Communication related */
        public static String HostAdress                { get; set; } = "127.0.0.1";
        public static String HostPort                  { get; set; } = "6666";
        public static TcpClient ComSocket              { get; set; }

        /** Worker Threads instance */
        private static Thread SimulationThread;
        private static Thread CommunicationThread;

        /** Time manager */
        private static TimeManager timeManager;

        /** Events handler */
        public static event EventHandler CurrentProcessedLineChange;

        /// <summary>
        /// Launch the simulation by starting Workers thread
        /// </summary>
        public static bool Launch()
        {
            /** Init communication/connection stuff */
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(HostAdress), int.Parse(HostPort));
            ComSocket = new TcpClient();
            try
            {
                ComSocket.Connect(endPoint);

                if (!ComSocket.Connected)
                {
                    return false;
                }
                else
                {
                    /** Send begin message */
                    Byte[] bytes = System.Text.Encoding.ASCII.GetBytes(Messages.HelloMessage);
                    ComSocket.GetStream().Write(bytes, 0, bytes.Length);

                    /** Wait for response */
                    ComSocket.GetStream().ReadTimeout = 1000;
                    int retinit = ComSocket.GetStream().ReadByte();
                    if (retinit != 49)
                    {
                        return false;
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message, ConsoleColor.Red);
                return false;
            }

            /** Init stuff to manage threads and time */
            timeManager = TimeManager.Instance;
            PauseEvent = new ManualResetEvent(true);
            SimSyncEvent = new ManualResetEvent(false);
            ComSyncEvent = new ManualResetEvent(true);

            /** Init agents stuff */
            AgsManager = new AgentsManager();
            AgsManager.Setup(CurrentEpisode);

            /** Send character to render app in order to setup gameobjects */
            string characterInitMessage = Messages.CreateCharacterAgentInitMessage(AgsManager.GetCharacterAgentsData());
            byte[] tosend = System.Text.Encoding.ASCII.GetBytes(characterInitMessage);
            ComSocket.GetStream().Write(tosend, 0, tosend.Length);

            /** Wait for response in order to check for possible problems */
            ComSocket.GetStream().ReadTimeout = 5000;
            int ret = ComSocket.GetStream().ReadByte();
            if(ret != 49)
            {
                return false;
            }

            /** Launch worker threads */
            SimulationThread = new Thread(Workers.SimulationWorker);
            CommunicationThread = new Thread(Workers.CommunicationWorker);
            SimulationThread.Start();
            CommunicationThread.Start();

            return true;
        }

        /// <summary>
        /// Block thread, pause the simulation in current state
        /// </summary>
        public static void Pause()
        {
            SimulationShouldPause = true;
            PauseEvent.Reset();
        }

        /// <summary>
        /// Unblock thread
        /// </summary>
        public static void Unpause()
        {
            SimulationShouldPause = false;
            PauseEvent.Set();
        }

        /// <summary>
        /// Stop simulation thread
        /// </summary>
        public static void Stop()
        {
            /** Stop simulation and wait worker thread to join */
            SimulationShouldRun = false;

            /** Unblock sync between threads */
            SimSyncEvent.Set();
            ComSyncEvent.Set();

            SimulationThread.Join();
            CommunicationThread.Join();

            ComSocket.GetStream().Write(System.Text.Encoding.ASCII.GetBytes(Messages.EndMessage), 0, Messages.EndMessage.Length);
            ComSocket.Close();
        }
    }
}
