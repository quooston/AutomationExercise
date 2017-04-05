using System;
using System.Linq;

namespace SampleWebApp.Automation.Helpers.Utility
{
    public class StringUtility
    {
        private static readonly Random Random = new Random();

        public static string RandomString(int minLength, int maxLength)
        {
            var input = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var size = Random.Next(minLength, maxLength);
            var chars = Enumerable.Range(0, size)
                                   .Select(x => input[Random.Next(0, input.Length)]);
            return new string(chars.ToArray());
        }
    }
}