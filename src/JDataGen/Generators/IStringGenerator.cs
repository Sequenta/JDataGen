namespace JDataGen.Generators
{
  public interface IStringGenerator : IGenerator
  {
    IStringGenerator Length(int number);
    IStringGenerator Format(string formatString);
    IStringGenerator CharacterSet(string set);
  }
}
