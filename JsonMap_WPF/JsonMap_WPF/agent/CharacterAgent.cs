using System;

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

        public void Update()
        {
            
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
