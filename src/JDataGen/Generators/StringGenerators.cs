namespace JDataGen.Generators
{
    public class StringGenerators
    {
        public static IStringGenerator Random()
        {
            return new RandomStringGenerator();
        }

        public static IStringGenerator Name()
        {
            return new RandomStringGenerator();
        }
    }
}