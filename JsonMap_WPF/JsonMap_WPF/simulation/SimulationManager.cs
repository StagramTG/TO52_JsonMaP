using System;
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
    }
}
