namespace JsonMap.Simulation
{
    public class SimulationConfig
    {
        /**
         * Weight constants
         */
        public const float WEIGHT_START                              = 10f;
        public const float WEIGHT_STEP                               = 0.5f;

        public const float WEIGHT_MAX                                = 100f;
        public const float WEIGHT_MIN                                = 5f;

        public const float WEIGHT_MULT_FACTOR_POSITIVE_INFLUENCE     = 1f;
        public const float WEIGHT_MULT_FACTOR_NEGATIVE_INFLUENCE     = -1f;
        public const float WEIGHT_MULT_FACTOR_NEUTRAL_INFLUENCE      = 0f;

        public const float WEIGHT_MULT_FACTOR_ACTIVE                 = 1f;
        public const float WEIGHT_MULT_FACTOR_PASSIVE                = 0.5f;
        public const float WEIGHT_MULT_FACTOR_NOT_INVOLVED           = 0f;

        /**
         * Influence constants
         */
        public const int INFLUENCE_MAX_POSITIVE            = 20;
        public const int INFLUENCE_NEUTRAL                 = 0;
        public const int INFLUENCE_MAX_NEGATIVE            = -20;

        public const int INFLUENCE_FACTOR_POSITIVE         = 1;
        public const int INFLUENCE_FACTOR_NEUTRAL          = 0;
        public const int INFLUENCE_FACTOR_NEGATIVE         = -1;

        /**
         * Strengh constants
         */
        public const float STRENGH_MAX = 10f;
        public const float STRENGH_MIN = 1f;

        public const float STRENGH_FACTOR = 0.5f;
    }
}
