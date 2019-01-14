using System;
using System.Collections.Generic;

using JsonMap.Simulation;

namespace JsonMap.Math
{
    public class RigidBody
    {
        private TimeManager timeManager;

        /**
         * ==========================================
         *      PROPERTIES
         * ==========================================
         */
        public Vector3 Position         { get; set; }
        public Vector3 Velocity         { get; private set; }
        public float FrictionFactor     { get; private set; }
        public float Speed              => Velocity.Norm;

        public bool UseGravity          { get; set; } = true;

        public RigidBody()
        {
            Position = new Vector3(0, 0, 0);
            Velocity = new Vector3(0, 0, 0);
            FrictionFactor = 0.1f;

            timeManager = TimeManager.Instance;
        }

        public RigidBody(Vector3 pposition)
        {
            Position = pposition;
            Velocity = new Vector3(0, 0, 0);

            timeManager = TimeManager.Instance;
        }

        public void ApplyForce(Vector3 pforce)
        {
            Velocity += pforce;
        }

        public void Update()
        {
            // Check if gravity influence the Rigid Body
            if(UseGravity)
            {
                // Apply Gravity
                Velocity += Physics.Gravity * timeManager.DeltaTime;
            }

            // Apply velocity to position
            Velocity -= (Velocity * FrictionFactor);
            if(Velocity.Norm > 100f)
            {
                Velocity = Velocity.Normalized * 100f;
            }

            Position += Velocity * timeManager.DeltaTime;

            // Bound distance
            if(Position.Norm > 10f)
            {
                Position = Position.Normalized * 10f;
            }
        }
    }
}
