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

        public CharacterAgent(Character pcharacter)
        {
            CharacterData = pcharacter;

            Weight = Simulation.SimulationConfig.WEIGHT_START;
            Body = new RigidBody();
        }

        public void Update(List<Simulation.Relation> prelations)
        {
            // Process force to apply
            foreach(Simulation.Relation relation in prelations)
            {
                // Find vector to other agent of the relation
                Vector3 startPoint = relation.involvedAgents.Item1.CharacterData.Id == CharacterData.Id ? 
                    relation.involvedAgents.Item1.Body.Position : 
                    relation.involvedAgents.Item2.Body.Position;

                Vector3 endPoint = relation.involvedAgents.Item1.CharacterData.Id != CharacterData.Id ?
                    relation.involvedAgents.Item1.Body.Position :
                    relation.involvedAgents.Item2.Body.Position;

                Vector3 direction = endPoint - startPoint;
                direction = (direction * relation.nature).Normalized;

                // Process relation in order to apply force
                Body.ApplyForce(direction);
            }

            // Apply force
        }

        /** Convert current Agent's attributes to CharacterAgentData (Serializable) */
        public CharacterAgentData ToCharacterAgentData()
        {
            CharacterAgentData data = new CharacterAgentData();
            data.Id = CharacterData.Id;
            data.Name = CharacterData.Name;
            data.Position = Body.Position;
            data.Weight = Weight;

            return data;
        }
    }
}
