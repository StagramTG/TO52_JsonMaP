using System;
using System.Collections.Generic;

namespace JsonMap.Data
{
    /**
     * Structure RelationData
     * 
     * Stored data are aimed to be transformed in JSON format in order
     * to be sent to render application.
     */
    public struct RealtionData
    {
        public int Agent1ID { get; set; }
        public int Agent2ID { get; set; }

        public float Strengh { get; set; }
        public float Nature { get; set; }
    }
}
