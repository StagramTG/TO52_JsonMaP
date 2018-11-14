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
            PASSIVE
        }

        /** identification attributes */
        public Character CharacterData { get; private set; }

        /** Physical attributes */
        RigidBody rigidBody;

        public CharacterAgent(Character pcharacter)
        {
            CharacterData = pcharacter;

            rigidBody = new RigidBody();
        }

        public void Update(Data.Action action, Behaviors behavior)
        {
            switch(behavior)
            {
                /** When character is an actor of the action */
                case Behaviors.ACTIVE:
                    ProcessActiveBehavior(action);
                    break;

                /** When character is a target in action */
                case Behaviors.PASSIVE:
                    ProcessPassiveBehavior(action);
                    break;
            }
        }

        private void ProcessActiveBehavior(Data.Action action)
        {
            
        }

        private void ProcessPassiveBehavior(Data.Action action)
        {

        }
    }
}
