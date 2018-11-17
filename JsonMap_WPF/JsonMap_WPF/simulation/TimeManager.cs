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

        /** Last register time */
        public DateTime LastTime { get; private set; }
        /** Elapsed time since last Update in seconds */
        public float DeltaTime { get; private set; } 

        private TimeManager()
        {
            LastTime = DateTime.Now;
            DeltaTime = 0;
        }

        public void Update()
        {
            DateTime currentTime = DateTime.Now;
            DeltaTime = (currentTime - LastTime).Milliseconds / 1000f;
            LastTime = currentTime;
        }
    }
}
