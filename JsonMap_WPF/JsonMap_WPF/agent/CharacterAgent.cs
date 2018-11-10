using System;

using JsonMap;
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

        /** identification attributes */
        public String Name { get; private set; }
        public int Id { get; private set; }

        /** Physical attributes */
        public int Weight { get; private set; }
        public Vector3 Position { get; private set; }

        public CharacterAgent(String name, int id)
        {
            Name = name;
            Id = id;
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
