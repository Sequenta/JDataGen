using System;

namespace JDataGen.Generators
{
  public class DoubleGenerator : NumberGenerator<double>
  {
    private static Random random = new Random();

    public override object Generate()
    {
        if (max == 0)
        {
            max = 100;
        }
        return (double)random.Next((int)min, (int)max);
    }
  }
}
