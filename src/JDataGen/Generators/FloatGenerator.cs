using System;

namespace JDataGen.Generators
{
  public class FloatGenerator : NumberGenerator<float>
  {
    private static Random random = new Random();

    public override object Generate()
    {
        if (max == 0)
        {
            max = 100;
        }
        return (float)random.Next((int) min, (int) max);
    }
  }
}
