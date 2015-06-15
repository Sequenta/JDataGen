using JDataGen.Generators;
using Xunit;

namespace JDataGen.Tests.Generators
{
  public class NumberGeneratorsTests
  {
    [Fact]
    public void IntGeneratorTest()
    {
        var generator = NumberGenerators.Int().Min(1).Max(5);

        var result = generator.Generate();

        Assert.IsType(typeof(int),result);
    }

    [Fact]
    public void FloatGeneratorTest()
    {
        var generator = NumberGenerators.Float().Min(1).Max(5);

        var result = generator.Generate();

        Assert.IsType(typeof(float), result);
    }

    [Fact]
    public void DoubleGeneratorTest()
    {
        var generator = NumberGenerators.Double().Min(1).Max(5);

        var result = generator.Generate();

        Assert.IsType(typeof(double), result);
    }
  }
}
