using System;
using System.Collections.Generic;

using JsonMap.Data;
using JsonMap.Math;

namespace JsonMap.Agent
{
    /** Agent aims to simulate Character */
    public class CharacterAgent
    {
        /** identification attributes */
        public Character CharacterData { get; private set; }

        /** Physical attributes */
        public float Weight   { get; set; }
        public RigidBody Body { get; private set; }

        /** Relations */
        private Dictionary<int, Simulation.Relation> relations;

        public CharacterAgent(Character pcharacter)
        {
            CharacterData = pcharacter;

            Weight = Simulation.SimulationConfig.WEIGHT_START;
            Body = new RigidBody();
            relations = new Dictionary<int, Simulation.Relation>();
        }

        public int[] UpdateRelation(Data.Action paction)
        {
            List<int> processedRelation = new List<int>();

            // Update relation with action influence
            foreach(int id in paction.CharactersId)
            {
                if(id == CharacterData.Id)
                    continue;

                // Check if relation exists
                Simulation.Relation r;
                bool find = relations.TryGetValue(id, out r);

                if(!find)
                {
                    // Create relation
                    r = new Simulation.Relation();
                    relations.Add(id, r);
                }

                // Check if relation is already processed for this step
                if(Simulation.SimulationManager.environment.ProcessedRelations.Contains(r.Id))
                    continue;

                // If not process it
                r.Update(paction.Influence);

                // Add this relation to processed
                processedRelation.Add(r.Id);
            }

            return processedRelation.ToArray();
        }

        public void UpdatePhysics()
        {
            // Update applyed forces
            foreach(var r in relations)
            {
                int agid = Simulation.SimulationManager.environment.Agents.FindIndex((a) => { 
                    return a.CharacterData.Id == r.Key;
                });

                if(agid == -1)
                    return;

                CharacterAgent ag = Simulation.SimulationManager.environment.Agents[agid];

                // Calculate forces

                // Apply forces
            }
            
            // Update body
            Body.Update();
        }

        /** Convert current Agent's attributes to CharacterAgentData (Serializable) */
        public CharacterAgentData ToCharacterAgentData()
        {
            CharacterAgentData data = new CharacterAgentData
            {
                Id = CharacterData.Id,
                Name = CharacterData.Name,
                Position = Body.Position,
                Weight = Weight
            };

            return data;
        }
    }
}
