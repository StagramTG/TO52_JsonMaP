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
            // Update relation with action influence
            return new int[0];
        }

        public void UpdatePhysics()
        {
            // Update applyed forces

            // Apply forces
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
