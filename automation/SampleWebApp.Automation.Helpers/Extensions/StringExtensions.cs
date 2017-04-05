using System.Text.RegularExpressions;

namespace SampleWebApp.Automation.Helpers.Extensions
{
    public static class StringExtensions
    {
        public static bool IsValidRegexPattern(this string pattern)
        {
            try
            {
                var regex = new Regex(pattern);
                return true;
            }
            catch
            {
                // ignored
            }
            return false;
        }
    }
}