using System;
using System.Collections.Generic;

using JsonMap.Agent;

namespace JsonMap.simulation
{
    public class Relation
    {
        private Tuple<CharacterAgent, CharacterAgent> involvedAgents;
        private float strengh;
        private float nature;

        public Relation(CharacterAgent pAgent1, CharacterAgent pAgent2)
        {
            involvedAgents = new Tuple<CharacterAgent, CharacterAgent>(pAgent1, pAgent2);
            strengh = 0f;
            nature = 0f;
        }
    }
}
