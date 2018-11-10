using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace JsonMap.Data
{
    public class Episode
    {
        public string Title { get; set; }
        public uint LinesCount { get; set; }

        public List<Character> Characters { get; set; }
        public List<Action> Actions { get; set; }
    }
}
