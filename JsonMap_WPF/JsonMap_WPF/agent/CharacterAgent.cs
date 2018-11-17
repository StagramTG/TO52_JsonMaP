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
        public RigidBody Body { get; private set; }

        public CharacterAgent(Character pcharacter)
        {
            CharacterData = pcharacter;

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
             
        }

        private void ProcessPassiveBehavior(Data.Action paction)
        {

        }

        private void ProcessNotInvolvedBehavior(Data.Action paction)
        {
            
        }
    }
}
