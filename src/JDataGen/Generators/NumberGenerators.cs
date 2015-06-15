namespace JDataGen.Generators
{
    public class NumberGenerators
    {
        public static INumberGenerator<int> Int()
        {
            return new IntGenerator();
        }

        public static INumberGenerator<float> Float()
        {
            return new FloatGenerator();
        }

        public static INumberGenerator<double> Double()
        {
            return new DoubleGenerator();
        }
    }
}
