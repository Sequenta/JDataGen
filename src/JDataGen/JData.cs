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
        private Dictionary<Type, IGenerator> deafultBindings = new Dictionary<Type, IGenerator>
        {
              {typeof (int), NumberGenerators.Int()},
              {typeof (double), NumberGenerators.Double()},
              {typeof (float), NumberGenerators.Float()},
              {typeof (string), StringGenerators.Random()}
        };

        public List<PropertyGenConfiguration> GenConfigurations { get; set; }

        public JData()
        {
            GenConfigurations = new List<PropertyGenConfiguration>();
        }

        public string Gen(int count)
        {
            if (count == 0)
            {
                return string.Empty;
            }

            var list = new List<T>();
            for (var i = 0; i < count; ++i)
            {
                var item = (T)Activator.CreateInstance(typeof(T));
                foreach (var propertyInfo in item.GetType().GetProperties())
                {
                    var generator = GetGeneratorFromConfig(propertyInfo.Name);
                    if (generator == null)
                    {
                        generator = GetGeneratorFromDefaults(propertyInfo.PropertyType);
                    }
                    propertyInfo.SetValue(item, generator.Generate());
                }
                list.Add(item);
            }
            if (count > 1)
            {
                JsonConvert.SerializeObject(list);
            }
            return JsonConvert.SerializeObject(list.First());
        }

        public JData<T> Configure(Action<PropertyGenConfigurationFactory<T>> configurator)
        {
            var configurationFactory = new PropertyGenConfigurationFactory<T>(this);
            configurator(configurationFactory);
            return this;
        }

        private IGenerator GetGeneratorFromConfig(string propertyName)
        {
            var propertyGenConfiguration = GenConfigurations.FirstOrDefault(x => x.PropertyName == propertyName);
            return propertyGenConfiguration != null ? propertyGenConfiguration.Generator : null;
        }

        private IGenerator GetGeneratorFromDefaults(Type propertyType)
        {
            IGenerator generator;
            deafultBindings.TryGetValue(propertyType, out generator);
            return generator;
        }
    }
}
