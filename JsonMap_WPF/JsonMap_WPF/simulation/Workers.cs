using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonMap_WPF.simulation
{
    public static class Workers
    {
        /**
         * Method that runs in simulation Thread.
         * Runs multiagents system to calculate physical behaviors
         * based on interactions extract from episode's script.
         */
        public static void SimulationWorker()
        {

        }

        /**
         * Method that runs in communication Thread.
         * Send calculated data to render application through Socket.
         */
        public static void CommunicationWorker()
        {

        }
    }
}
