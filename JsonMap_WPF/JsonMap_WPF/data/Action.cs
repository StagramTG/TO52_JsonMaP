using System;
using System.Collections.Generic;

namespace JsonMap.Data
{
    public class Action
    {
        public uint Line { get; set; }
        public List<int> CharactersId { get; set; }
        public List<int> TargetsId { get; set; }
        public int Influence { get; set; }
    }
}
