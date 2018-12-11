using System;
using System.Collections.Generic;

using JsonMap.Data;
using JsonMap.Agent;

namespace JsonMap.Simulation
{
    public class Environment
    {
        public Dictionary<string, CharacterAgent> Agents { get; private set; }
        public int Count => Agents.Count;

        public Environment()
        {
            Agents = new Dictionary<string, CharacterAgent>();
        }

        public bool Setup(Episode pepisode)
        {
            // Create an agent for each characters for given episode
            foreach(Character character in pepisode.Characters)
            {
                CharacterAgent ca = new CharacterAgent(character);
                ca.Weight = (float)(character.Occ * 100f) / (float)pepisode.LinesCount;
                Agents.Add(character.Name, ca);
            }

            // Create relations

            return true;
        }

        /** Return a list of CharacterAgent convert in CharacterAgentData */
        public List<CharacterAgentData> GetCharacterAgentsData()
        {
            List<CharacterAgentData> data = new List<CharacterAgentData>();
            
            foreach(var agent in Agents)
            {
                data.Add(agent.Value.ToCharacterAgentData());
            }

            return data;
        }

        public void UpdateRelations()
        {

        }
    }
}
