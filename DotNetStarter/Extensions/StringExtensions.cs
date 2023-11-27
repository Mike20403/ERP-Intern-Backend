using System;

namespace DotNetStarter.Extensions
{
    public static class StringExtensions
    {
        public static string ToOrderBy(this List<string>? @this)
        {
            var orderBy = (@this ?? new List<string>()).ToArray();
            return string.Join(";", orderBy);
        }

        public static string GenerateCode(this string @this, int codeLength)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new string(Enumerable.Repeat(chars, codeLength).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
