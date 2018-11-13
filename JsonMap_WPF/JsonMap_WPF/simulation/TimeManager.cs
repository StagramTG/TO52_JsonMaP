using System;
using System.Collections.Generic;

namespace JsonMap.Simulation
{
    public class TimeManager
    {
        // Singleton
        private static TimeManager instance;
        public static TimeManager Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new TimeManager();
                }

                return instance;
            }
        }

        public int LastTime { get; private set; }
        public float DeltaTime { get; private set; } 

        private TimeManager()
        {
            LastTime = System.Environment.TickCount;
            DeltaTime = 0;
        }

        public void Update()
        {

        }
    }
}
