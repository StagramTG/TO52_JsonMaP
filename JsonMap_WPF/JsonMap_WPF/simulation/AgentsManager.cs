using System;
using System.Collections.Generic;

using JsonMap.Data;
using JsonMap.Agent;

namespace JsonMap.Simulation
{
    public class AgentsManager
    {
        Dictionary<string, CharacterAgent> agents;

        public AgentsManager()
        {
            agents = new Dictionary<string, CharacterAgent>();
        }

        public bool Setup(Episode pepisode)
        {
            // Create an agent for each characters for given episode
            

            return true;
        }
    }
}
