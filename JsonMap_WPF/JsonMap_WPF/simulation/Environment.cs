using System;
using System.Collections.Generic;

using JsonMap.Data;
using JsonMap.Agent;

namespace JsonMap.Simulation
{
    public class Environment
    {
        public List<CharacterAgent> Agents { get; private set; }
        public List<Relation> Relations { get; private set; }
        public int Count => Agents.Count;

        public Environment()
        {
            Agents = new List<CharacterAgent>();
            Relations = new List<Relation>();
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

            // Create relations for each possible agents couple
            for(int mainIndex = 0; mainIndex < (Agents.Count - 1); ++mainIndex)
            {
                for (int index = mainIndex+1; index < Agents.Count; ++index)
                {
                    if (Agents[index].CharacterData.Name != Agents[mainIndex].CharacterData.Name)
                    {
                        Relation r = new Relation(Agents[mainIndex], Agents[index]);
                        Tuple<string, string> k = new Tuple<string, string>(Agents[mainIndex].CharacterData.Name, Agents[index].CharacterData.Name);

                        Relations.Add(r);
                    }
                }
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

        public void UpdateRelations()
        {

        }
    }
}
