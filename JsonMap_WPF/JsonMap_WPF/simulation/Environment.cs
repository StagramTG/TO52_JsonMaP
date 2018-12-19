using System;
using System.Collections.Generic;

using JsonMap.Data;
using JsonMap.Agent;

namespace JsonMap.Simulation
{
    public class Environment
    {
        public List<CharacterAgent> Agents { get; private set; }
        public int Count => Agents.Count;

        public List<int> ProcessedRelations;

        public Environment()
        {
            Agents = new List<CharacterAgent>();

            ProcessedRelations = new List<int>();
        }

        public bool Setup(Episode pepisode)
        {
            Random rand = new Random();

            // Create an agent for each characters for given episode
            foreach(Character character in pepisode.Characters)
            {
                CharacterAgent ca = new CharacterAgent(character);
                ca.Weight = (float)(character.Occ * 100f) / (float)pepisode.LinesCount;
                ca.Body.Position = new Math.Vector3(rand.Next(20), 0f, rand.Next(20));
                Agents.Add(ca);
            }

            return true;
        }

        /** Return a list of CharacterAgent convert in CharacterAgentData */
        public List<CharacterAgentData> GetCharacterAgentsData()
        {
            List<CharacterAgentData> data = new List<CharacterAgentData>();
            
            foreach(var agent in Agents)
            {
                data.Add(agent.ToCharacterAgentData());
            }

            return data;
        }

        /**
         * 
         */
        public void UpdateAgentsRelations(Data.Action paction)
        {
            foreach (CharacterAgent agent in Agents)
            {
                ProcessedRelations.AddRange(agent.UpdateRelation(paction));
            }

            ProcessedRelations.Clear();
        }

        /**
         * This method update all agents physical property by applying 
         */
        public void UpdateAgents()
        {
            foreach(CharacterAgent agent in Agents)
            {
                agent.UpdatePhysics();
            }
        }
    }
}
