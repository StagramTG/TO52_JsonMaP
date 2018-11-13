using System;
using System.Collections.Generic;

namespace JsonMap.Math
{
    public class RigidBody
    {
        /**
         * ==========================================
         *      FIELDS
         * ==========================================
         */
        private Vector3 position;
        private Vector3 speed;
        private Vector3 acceleration;

        /**
         * ==========================================
         *      PROPERTIES
         * ==========================================
         */
        public Vector3 Position        => position;
        public Vector3 Speed           => speed;
        public Vector3 Acceleration    => acceleration;

        public bool UseGravity { get; set; } = true;

        public RigidBody()
        {
            position = new Vector3(0, 0, 0);
            speed = new Vector3(0, 0, 0);
            acceleration = new Vector3(0, 0, 0);
        }

        public RigidBody(Vector3 pposition)
        {
            position = pposition;
            speed = new Vector3(0, 0, 0);
            acceleration = new Vector3(0, 0, 0);
        }

        public void ApplyForce(Vector3 pforce)
        {

        }

        public void Update()
        {
            // Check if gravity influence the Rigid Body
            if(UseGravity)
            {
                // Apply Gravity
            }

            // Apply acceleration to speed

            // Apply speed to position
        }
    }
}
