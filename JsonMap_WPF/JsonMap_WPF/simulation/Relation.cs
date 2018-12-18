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
    }
}
