using FluentAssertions;
using JDataGen;
using JDataGen.Configuration;
using JDataGen.Generators;
using Newtonsoft.Json;
using System.Collections.Generic;
using Xunit;

namespace JDataGen.Tests
{
  public class GeneratorTests
  {
    [Fact]
    public void SingleInstanceGenTest()
    {
      TestClass testClass = JsonConvert.DeserializeObject<TestClass>(new JData<TestClass>().Gen(1));
      Assert.False(string.IsNullOrEmpty(testClass.FirstName));
      Assert.False(string.IsNullOrEmpty(testClass.SecondName));
    }

    [Fact]
    public void CollectionGenTest()
    {
      int num = 3;
      JsonConvert.DeserializeObject<IEnumerable<TestClass>>(new JData<TestClass>().Gen(num)).Should().HaveCount(num, "");
    }

    [Fact]
    public void GeneratorsConfigurationTest()
    {
      Assert.IsType<int>(JsonConvert.DeserializeObject<TestClass>(new JData<TestClass>().Configure(configuration =>
      {
          configuration.For(field => field.IntValue).Use(NumberGenerators.Int());
          configuration.For(field => field.FloatValue).Use(NumberGenerators.Float().Max(5f));
          configuration.For(field => field.DoubleValue).Use(NumberGenerators.Int().Min(5).Max(10));
      }).Gen(1)).IntValue);
    }
  }
}
