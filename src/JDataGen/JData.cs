// Decompiled with JetBrains decompiler
// Type: JDataGen.JData`1
// Assembly: JDataGen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4665FFF2-68FC-4A07-B165-9FF7F57ED80D
// Assembly location: D:\JDataGen\src\JDataGen\bin\Debug\JDataGen.dll

using JDataGen.Configuration;
using JDataGen.Generators;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JDataGen
{
  public class JData<T>
  {
    private Dictionary<Type, IGenerator> deafultBindings = new Dictionary<Type, IGenerator>()
    {
      {typeof (int),NumberGenerators.Int()},
      {typeof (double),NumberGenerators.Double()},
      {typeof (float),NumberGenerators.Float()},
      {typeof (string),new RandomStringGenerator()}
    };

    public List<PropertyGenConfiguration> GenConfigurations { get; set; }

    public string Gen(int count)
    {
      if (count == 0)
        return string.Empty;
      var list = new List<T>();
      for (var index = 0; index < count; ++index)
      {
        var obj = (T) Activator.CreateInstance(typeof (T));
        foreach (var propertyInfo in obj.GetType().GetProperties())
          propertyInfo.SetValue(obj, "Test String");
        list.Add(obj);
      }
      return JsonConvert.SerializeObject(list.Take(count));
    }

    public JData<T> Configure(Action<PropertyGenConfigurationFactory<T>> configurator)
    {
      var configurationFactory = new PropertyGenConfigurationFactory<T>(this);
      configurator(configurationFactory);
      return this;
    }
  }
}
