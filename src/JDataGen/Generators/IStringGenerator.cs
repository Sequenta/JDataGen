namespace JDataGen.Generators
{
  public interface IStringGenerator : IGenerator
  {
    IStringGenerator Length(int length);
    IStringGenerator Format(string format, IGenerator argsGenerator);
    IStringGenerator CharacterSet(string set);
    IStringGenerator IncludeDigits(bool flag);
  }
}
