using JDataGen.Generators;
using Xunit;

namespace JDataGen.Tests.Generators
{
  public class NumberGeneratorsTests
  {
    [Fact]
    public void IntGeneratorTest()
    {
      Assert.True(NumberGenerators.Int().Min(1).Max(5).Generate() is int);
    }

    [Fact]
    public void FloatGeneratorTest()
    {
      Assert.True(NumberGenerators.Float().Min(1f).Max(5f).Generate() is float);
    }

    [Fact]
    public void DoubleGeneratorTest()
    {
      Assert.True(NumberGenerators.Double().Min(1.0).Max(5.0).Generate() is double);
    }
  }
}
