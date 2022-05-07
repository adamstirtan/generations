namespace Generations.Core.Extensions
{
    public static class StringExtensions
    {
        public static string SqlEscape(this string s)
        {
            return s.Replace("'", "''");
        }
    }
}