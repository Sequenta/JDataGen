using System;

namespace JDataGen.Generators
{
    public class IntGenerator : NumberGenerator<int>
    {
        private static Random random = new Random();

        public override object Generate()
        {
            if (max == 0)
            {
                max = 100;
            }
            return random.Next(min, max);
        }
    }
}
