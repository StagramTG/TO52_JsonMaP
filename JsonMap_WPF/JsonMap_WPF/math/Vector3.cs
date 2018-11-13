using System;

namespace JsonMap.Math
{
    /// <summary>
    /// Simple data structure that represent 3D vector
    /// </summary>
    public struct Vector3
    {
        /**
         * ==========================================
         *      FIELDS
         * ==========================================
         */
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        /**
         * ==========================================
         *      PROPERTIESS
         * ==========================================
         */
        public Vector3 Forward   => new Vector3(0,0,1);
        public Vector3 Left      => new Vector3(-1,0,0);
        public Vector3 Right     => new Vector3(1,0,0);
        public Vector3 Up     => new Vector3(0,1,0);

        /**
         * ==========================================
         *      CONSTRUCTORS
         * ==========================================
         */
        public Vector3(float px, float py, float pz)
        {
            X = px;
            Y = py;
            Z = pz;
        }

        public Vector3(float px, float py)
        {
            X = px;
            Y = py;
            Z = 0f;
        }

        public Vector3(float pxyz)
        {
            X = pxyz;
            Y = pxyz;
            Z = pxyz;
        }
    }
}
