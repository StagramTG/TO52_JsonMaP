using System;
using System.Collections.Generic;

using JsonMap.Agent;

namespace JsonMap.Simulation
{
    public class Relation
    {
        /** Constants for nature */
        public const float NATURE_NEUTRAL  = 0;
        public const float NATURE_POSITIVE = 1;
        public const float NATURE_NEGATIVE = -1;

        /** Strengh constants */
        public const float STRENGH_MAX = 5;

        public Tuple<CharacterAgent, CharacterAgent> involvedAgents;
        public float strengh;
        public float nature;

        public Relation(CharacterAgent pAgent1, CharacterAgent pAgent2)
        {
            involvedAgents = new Tuple<CharacterAgent, CharacterAgent>(pAgent1, pAgent2);
            strengh = 0f;
            nature = 0f;
        }
    }
}
