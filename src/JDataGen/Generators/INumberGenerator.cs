namespace JDataGen.Generators
{
  public interface INumberGenerator<in T> : IGenerator
  {
    INumberGenerator<T> Min(T minValue);
    INumberGenerator<T> Max(T maxValue);
  }
}
