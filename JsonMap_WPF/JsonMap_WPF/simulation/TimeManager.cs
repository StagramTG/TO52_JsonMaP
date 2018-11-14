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

        public DateTime LastTime { get; private set; }
        public float DeltaTime { get; private set; } 

        private TimeManager()
        {
            LastTime = DateTime.Now;
            DeltaTime = 0;
        }

        public void Update()
        {
            DateTime currentTime = DateTime.Now;
            DeltaTime = (LastTime - currentTime).Milliseconds / 1000f;
            LastTime = currentTime;
        }
    }
}
