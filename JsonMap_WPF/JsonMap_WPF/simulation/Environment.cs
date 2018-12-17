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
         * This method update all agents of the simulation by passing related relations
         * to each one. Each agent process his relations in order to apply forces to his body.
         * 
         * Relations are handled by the environment, agents never modify his relations.
         */
        public void UpdateAgents()
        {
            foreach(CharacterAgent agent in Agents)
            {
                // Fetch relations for current agent
                List<Relation> agentsRelations = Relations.FindAll(delegate (Relation r)
                {
                    if(r.involvedAgents.Item1.CharacterData.Id == agent.CharacterData.Id)
                        return true;

                    if (r.involvedAgents.Item2.CharacterData.Id == agent.CharacterData.Id)
                        return true;

                    return false;
                });

                // Update agent
                agent.Update(agentsRelations);
            }
        }

        /**
         * This method try to get the relation between two agents but if this relation does not
         * exist it is created stored in list of relations and returned.
         * 
         * By creating relations this way, only used relations will be created and used. In fact
         * all agents are not linked to each others.
         */
        public Relation GetOrCreateRelation(CharacterAgent pagent1, CharacterAgent pagent2)
        {
            /** Try to get relation if it exists */
            int search = Relations.FindIndex(delegate (Relation r)
            {
                if(r.involvedAgents.Item1.CharacterData.Id == pagent1.CharacterData.Id &&
                    r.involvedAgents.Item2.CharacterData.Id == pagent2.CharacterData.Id)
                {
                    return true;
                }

                if (r.involvedAgents.Item1.CharacterData.Id == pagent2.CharacterData.Id &&
                    r.involvedAgents.Item2.CharacterData.Id == pagent1.CharacterData.Id)
                {
                    return true;
                }

                return false;
            });

            Console.WriteLine("relation index: " + search);

            if (search == -1)
            {
                Relation r = new Relation(pagent1, pagent2);
                Relations.Add(r);
                return r;
            }

            return Relations[search];
        }
    }
}
