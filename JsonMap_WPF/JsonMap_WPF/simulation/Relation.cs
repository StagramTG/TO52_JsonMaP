using System;

namespace JsonMap.Simulation
{
    /**
     * Structure Relation
     * 
     * Represents relation's caracteristics between two Character agents
     * that are influence by actions.
     */
    public class Relation
    {
        private static int idCount = 0;

        public int Id { get; set; }
        public float Strengh { get; set; }
        public float Nature { get; set; }

        public Relation()
        {
            Id = idCount++;
            Strengh = 0;
            Nature = 0;
        }

        /**
         * Processed the relation using the given influence
         * This influence has an impact on the nature and the strengh of
         * the current relation.
         * 
         * Must be called only once each processing step.
         */
        public void Update(int pinfluence)
        {
            // Each occurence of the relation make it stronger
            Strengh++;
            // Influence has an impact on the nature of the relation
            Nature += pinfluence;
        }
    }
}
