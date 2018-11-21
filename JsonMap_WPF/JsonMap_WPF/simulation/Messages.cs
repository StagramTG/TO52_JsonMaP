using System;
using System.Collections.Generic;
using Newtonsoft.Json;

using JsonMap.Data;

namespace JsonMap.Simulation
{
    public static class Messages
    {
        public static string HelloMessage = JsonConvert.SerializeObject(new MessageData<object>(0, null));
        public static string EndMessage = JsonConvert.SerializeObject(new MessageData<object>(1, null));

        public static string CreateCharacterAgentInitMessage(List<CharacterAgentData> pcharacterAgents)
        {
            return JsonConvert.SerializeObject(new MessageData<List<CharacterAgentData>>(2, pcharacterAgents));
        }
    }
}
