using System;
using System.Text;

namespace JDataGen.Generators
{
    public class RandomStringGenerator : IStringGenerator
    {
        private static readonly Random random = new Random();

        private static string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
       
        private string customSet = string.Empty;
        private string format = string.Empty;
        private int length;

        public object Generate()
        {
            var source = string.IsNullOrEmpty(customSet) ? letters : customSet;
            if (length == 0)
            {
                length = random.Next(1, 10);
            }
            var builder = new StringBuilder();
            for (var i = 0; i < length; i++)
            {
                builder.Append(source[random.Next(1, source.Length)]);
            }
            return string.IsNullOrEmpty(format) ? builder.ToString() : 
                                                  string.Format(format, builder);
        }

        public IStringGenerator Length(int number)
        {
            length = number;
            return this;
        }

        public IStringGenerator Format(string formatString)
        {
            format = formatString;
            return this;
        }

        public IStringGenerator CharacterSet(string set)
        {
            customSet = set;
            return this;
        }
    }
}
