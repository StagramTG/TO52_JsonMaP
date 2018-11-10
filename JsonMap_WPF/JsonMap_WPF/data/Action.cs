using System;
using System.Collections.Generic;

namespace JsonMap.Data
{
    public class Action
    {
        /**
         * Constants for actions' influences
         */
        public const int INFLUENCE_POSITIVE = 1;
        public const int INFLUENCE_NEUTRAL = 0;
        public const int INFLUENCE_NEGATIVE = -1;

        public uint Line { get; set; }
        public List<int> CharacterId { get; set; }
        public List<int> TargetId { get; set; }
        public int Influence { get; set; }
    }
}
