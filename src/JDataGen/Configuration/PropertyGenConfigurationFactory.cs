using JDataGen.Extensions;
using JDataGen.Generators;
using System;
using System.Linq.Expressions;

namespace JDataGen.Configuration
{
  public class PropertyGenConfigurationFactory<T>
  {
    private readonly JData<T> instance;
    private PropertyGenConfiguration configuration;

    public PropertyGenConfigurationFactory(JData<T> instance)
    {
      this.instance = instance;
    }

    public PropertyGenConfigurationFactory<T> For<TValue>(Expression<Func<T, TValue>> expression)
    {
      configuration.PropertyName = expression.GetName();
      return this;
    }

    public void Use(IGenerator generator)
    {
      configuration.Generator = generator;
      instance.GenConfigurations.Add(configuration);
    }
  }
}
