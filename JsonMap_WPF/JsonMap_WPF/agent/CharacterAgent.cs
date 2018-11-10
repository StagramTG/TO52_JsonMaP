using System;

namespace JsonMap.Agent
{
    public class CharacterAgent
    {
        public String Name { get; private set; }
        public int Id { get; private set; }
        public int Weight { get; private set; }

        public CharacterAgent(String name, int id)
        {
            Name = name;
            Id = id;
        }

        public void Update()
        {

        }
    }
}
