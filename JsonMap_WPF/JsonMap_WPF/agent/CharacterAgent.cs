using System;

using JsonMap;
using JsonMap.Data;
using JsonMap.Math;

namespace JsonMap.Agent
{
    /// <summary>
    /// Agent aims to simulate Character
    /// </summary>
    public class CharacterAgent
    {
        /// <summary>
        /// Behavior of character in given action, he is a target or an
        /// active actor.
        /// </summary>
        public enum Behaviors
        {
            ACTIVE,
            PASSIVE
        }

        public static readonly float DEFAULT_WEIGHT = 0f;
        public static readonly Vector3 DEFAULT_POSITION = new Vector3(0, 0, 0);

        /** identification attributes */
        public Character CharacterData { get; private set; }

        /** Physical attributes */
        public float Weight { get; private set; }
        public Vector3 Position { get; private set; }

        public CharacterAgent(Character pcharacter)
        {
            CharacterData = pcharacter;

            Weight = DEFAULT_WEIGHT;
            Position = DEFAULT_POSITION;
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
