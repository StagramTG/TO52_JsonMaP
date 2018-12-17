using System;
using System.Collections.Generic;

using JsonMap.Agent;

namespace JsonMap.Simulation
{
    public class Relation
    {
        /** Strengh constants */
        public const float STRENGH_MAX = 5;

        public Tuple<CharacterAgent, CharacterAgent> involvedAgents;
        public float strengh;
        public float nature;

        public Relation(CharacterAgent pAgent1, CharacterAgent pAgent2)
        {
            involvedAgents = new Tuple<CharacterAgent, CharacterAgent>(pAgent1, pAgent2);
            strengh = SimulationConfig.STRENGH_MIN;
            nature = 0f;
        }

        public void ApplyAction(Data.Action paction)
        {
            // Process the nature of the relation
            switch(paction.Influence)
            {
                case SimulationConfig.INFLUENCE_FACTOR_NEGATIVE:
                    nature = System.Math.Max(nature + SimulationConfig.INFLUENCE_FACTOR_NEGATIVE, SimulationConfig.INFLUENCE_MAX_NEGATIVE);
                    break;

                case SimulationConfig.INFLUENCE_FACTOR_NEUTRAL:
                    nature = System.Math.Min(nature + SimulationConfig.INFLUENCE_FACTOR_NEUTRAL, SimulationConfig.INFLUENCE_MAX_POSITIVE);
                    break;

                case SimulationConfig.INFLUENCE_FACTOR_POSITIVE:
                    nature += SimulationConfig.INFLUENCE_FACTOR_POSITIVE;
                    break;
            }

            // Process strengh of the relation
            strengh = System.Math.Min(
                System.Math.Max(strengh + SimulationConfig.STRENGH_FACTOR, SimulationConfig.STRENGH_MIN), 
                SimulationConfig.STRENGH_MAX
            );
        }
    }
}
