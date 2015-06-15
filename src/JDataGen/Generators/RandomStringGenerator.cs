using System;

namespace JDataGen.Generators
{
  public class RandomStringGenerator : IStringGenerator, IGenerator
  {
    private static string ruSet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя";
    private static string enSet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
    private static string numSes = "0123456789";

    public object Generate()
    {
      throw new NotImplementedException();
    }

    public IStringGenerator Length(int length)
    {
      throw new NotImplementedException();
    }

    public IStringGenerator Format(string format, IGenerator argsGenerator)
    {
      throw new NotImplementedException();
    }

    public IStringGenerator CharacterSet(string set)
    {
      throw new NotImplementedException();
    }

    public IStringGenerator IncludeDigits(bool flag)
    {
      throw new NotImplementedException();
    }
  }
}
