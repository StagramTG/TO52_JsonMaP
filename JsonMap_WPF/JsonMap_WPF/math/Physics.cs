using System;
using System.Collections.Generic;

namespace JsonMap.Math
{
    public static class Physics
    {
        private static Vector3 gravity = new Vector3(0f, -9.8f, 0f);
        public static Vector3 Gravity => gravity;

        public static void SetGravity(float px, float py, float pz)
        {
            gravity.X = px;
            gravity.Y = py;
            gravity.Z = pz;
        }

        public static void SetGravity(Vector3 pgravity)
        {
            gravity = pgravity;
        }
    }
}
