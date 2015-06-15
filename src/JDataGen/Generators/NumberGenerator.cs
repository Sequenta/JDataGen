namespace JDataGen.Generators
{
  public abstract class NumberGenerator<T> : INumberGenerator<T>
  {
    protected T min;
    protected T max;

    public abstract object Generate();

    public INumberGenerator<T> Min(T minValue)
    {
      min = minValue;
      return this;
    }

    public INumberGenerator<T> Max(T maxValue)
    {
      max = maxValue;
      return this;
    }
  }
}
