using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonMap.Data
{
    public struct MessageData<DataType>
    {
        public int Type { get; set; }
        public DataType Data { get; set; }

        public MessageData(int ptype, DataType pdata)
        {
            Type = ptype;
            Data = pdata;
        }
    }
}
