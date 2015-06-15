using System;

namespace JDataGen.Generators
{
  public class IntGenerator : NumberGenerator<int>
  {
    private static Random random = new Random();

    public override object Generate()
    {
        return max != 0
             ? random.Next(min, max)
             : random.Next();
    }
  }
}
