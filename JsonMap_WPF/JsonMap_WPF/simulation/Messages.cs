using System;
using Newtonsoft.Json;

namespace JsonMap.Simulation
{
    public static class Messages
    {
        public static string HelloMessage = JsonConvert.SerializeObject(new MessageData<object>(0, null));
        public static string EndMessage = JsonConvert.SerializeObject(new MessageData<object>(1, null));
    }

    public struct MessageData<DataType>
    {
        public int Type         { get; set; }
        public DataType Data    { get; set; }

        public MessageData(int ptype, DataType pdata)
        {
            Type = ptype;
            Data = pdata;
        }
    }
}
