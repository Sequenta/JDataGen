using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using JDataGen.Generators;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace JDataGen.Tests
{
    public class GeneratorTests
    {
        [Fact]
        public void SingleInstanceGenTest()
        {
            var jdata = new JData<TestClass>().Gen(1);

            var data = JsonConvert.DeserializeObject<TestClass>(jdata);

            Assert.False(string.IsNullOrEmpty(data.FirstName));
            Assert.False(string.IsNullOrEmpty(data.SecondName));
        }

        [Fact]
        public void CollectionGenTest()
        {
            var number = 3;
            var jdata = new JData<TestClass>().Gen(number);

            var data = JsonConvert.DeserializeObject<IEnumerable<TestClass>>(jdata);

            data.Should().HaveCount(number);
        }

        [Fact]
        public void GeneratorsConfigurationTest()
        {
            var jdata = new JData<TestClass>().Configure(configuration =>
            {
                configuration.For(field => field.IntValue).Use(NumberGenerators.Int());
                configuration.For(field => field.FloatValue).Use(NumberGenerators.Float().Max(5));
                configuration.For(field => field.DoubleValue).Use(NumberGenerators.Int().Min(5).Max(10));
            }).Gen(1);

            var data = JsonConvert.DeserializeObject<TestClass>(jdata);

            Assert.IsType(typeof(int), data.IntValue);
        }
    }
}
