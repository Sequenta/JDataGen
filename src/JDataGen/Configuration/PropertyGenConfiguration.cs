using JDataGen.Generators;

namespace JDataGen.Configuration
{
  public class PropertyGenConfiguration
  {
    public string PropertyName { get; set; }

    public IGenerator Generator { get; set; }
  }
}
