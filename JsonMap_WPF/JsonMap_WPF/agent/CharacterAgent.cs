using System;

using JsonMap.Data;
using JsonMap.Math;

namespace JsonMap.Agent
{
    /** Agent aims to simulate Character */
    public class CharacterAgent
    {
        /** Behavior of character in given action, he is a target or an active actor. */
        public enum Behaviors
        {
            ACTIVE,
            PASSIVE,
            NOT_INVOLVED
        }

        /** identification attributes */
        public Character CharacterData { get; private set; }

        /** Physical attributes */
        public float Weight   { get; private set; }
        public RigidBody Body { get; private set; }

        public CharacterAgent(Character pcharacter)
        {
            CharacterData = pcharacter;

            Weight = Simulation.SimulationConfig.WEIGHT_START;
            Body = new RigidBody();
        }

        public void Update(Data.Action paction, Behaviors pbehavior)
        {
            switch(pbehavior)
            {
                /** When character is an actor of the action */
                case Behaviors.ACTIVE:
                    ProcessActiveBehavior(paction);
                    break;

                /** When character is a target in action */
                case Behaviors.PASSIVE:
                    ProcessPassiveBehavior(paction);
                    break;

                case Behaviors.NOT_INVOLVED:
                    ProcessNotInvolvedBehavior(paction);
                    break;
            }
        }

        private void ProcessActiveBehavior(Data.Action paction)
        {
            /** Process weight */
            ProcessWeight(Behaviors.ACTIVE, paction.Influence);

            /** Process relations */

            /** Process Physics */
        }

        private void ProcessPassiveBehavior(Data.Action paction)
        {
            /** Process weight */
            ProcessWeight(Behaviors.PASSIVE, paction.Influence);

            /** Process relations */

            /** Process Physics */
        }

        private void ProcessNotInvolvedBehavior(Data.Action paction)
        {
            /** Process weight */
            ProcessWeight(Behaviors.NOT_INVOLVED, paction.Influence);

            /** Process relations */

            /** Process Physics */
        }

        /** 
         * This function process the weight of the agent by taking in coonsideration the influence of the action
         * and the bahavior (if the actor is active, passive or not involved in the action)
         */
        private void ProcessWeight(Behaviors pbehaviors, int pinfluence)
        {
            switch(pbehaviors)
            {
                case Behaviors.ACTIVE:
                {
                    if (pinfluence > 0)
                    {
                        Weight += Simulation.SimulationConfig.WEIGHT_STEP * 
                            Simulation.SimulationConfig.WEIGHT_MULT_FACTOR_ACTIVE *
                            Simulation.SimulationConfig.WEIGHT_MULT_FACTOR_POSITIVE_INFLUENCE;
                    }
                    else if (pinfluence < 0)
                    {
                        Weight += Simulation.SimulationConfig.WEIGHT_STEP *
                            Simulation.SimulationConfig.WEIGHT_MULT_FACTOR_ACTIVE *
                            Simulation.SimulationConfig.WEIGHT_MULT_FACTOR_NEGATIVE_INFLUENCE;
                    }
                    else
                    {
                        Weight += Simulation.SimulationConfig.WEIGHT_STEP *
                            Simulation.SimulationConfig.WEIGHT_MULT_FACTOR_ACTIVE *
                            Simulation.SimulationConfig.WEIGHT_MULT_FACTOR_NEUTRAL_INFLUENCE;
                    }
                    break;
                }

                case Behaviors.PASSIVE:
                {
                    if (pinfluence > 0)
                    {
                        Weight += Simulation.SimulationConfig.WEIGHT_STEP *
                            Simulation.SimulationConfig.WEIGHT_MULT_FACTOR_PASSIVE *
                            Simulation.SimulationConfig.WEIGHT_MULT_FACTOR_POSITIVE_INFLUENCE;
                    }
                    else if (pinfluence < 0)
                    {
                        Weight += Simulation.SimulationConfig.WEIGHT_STEP *
                            Simulation.SimulationConfig.WEIGHT_MULT_FACTOR_PASSIVE *
                            Simulation.SimulationConfig.WEIGHT_MULT_FACTOR_NEGATIVE_INFLUENCE;
                    }
                    else
                    {
                        Weight += Simulation.SimulationConfig.WEIGHT_STEP *
                            Simulation.SimulationConfig.WEIGHT_MULT_FACTOR_PASSIVE *
                            Simulation.SimulationConfig.WEIGHT_MULT_FACTOR_NEUTRAL_INFLUENCE;
                    }
                    break;
                }

                case Behaviors.NOT_INVOLVED:
                {
                    if (pinfluence > 0)
                    {
                        Weight += Simulation.SimulationConfig.WEIGHT_STEP *
                            Simulation.SimulationConfig.WEIGHT_MULT_FACTOR_NOT_INVOLVED *
                            Simulation.SimulationConfig.WEIGHT_MULT_FACTOR_POSITIVE_INFLUENCE;
                    }
                    else if (pinfluence < 0)
                    {
                        Weight += Simulation.SimulationConfig.WEIGHT_STEP *
                            Simulation.SimulationConfig.WEIGHT_MULT_FACTOR_NOT_INVOLVED *
                            Simulation.SimulationConfig.WEIGHT_MULT_FACTOR_NEGATIVE_INFLUENCE;
                    }
                    else
                    {
                        Weight += Simulation.SimulationConfig.WEIGHT_STEP *
                            Simulation.SimulationConfig.WEIGHT_MULT_FACTOR_NOT_INVOLVED *
                            Simulation.SimulationConfig.WEIGHT_MULT_FACTOR_NEUTRAL_INFLUENCE;
                    }
                    break;
                }
            }
        }
    }
}
