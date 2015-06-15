using System;

namespace JDataGen.Generators
{
  public class FloatGenerator : NumberGenerator<float>
  {
    private static Random random = new Random();

    public override object Generate()
    {
        return (float)(max != 0
             ? random.Next((int)min, (int)max)
             : random.Next());
    }
  }
}
