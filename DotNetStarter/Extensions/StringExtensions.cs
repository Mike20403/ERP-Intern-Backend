namespace DotNetStarter.Extensions
{
    public static class StringExtensions
    {
        public static string ToOrderBy(this List<string>? @this)
        {
            var orderBy = (@this ?? new List<string>()).ToArray();
            return string.Join(";", orderBy);
        }
    }
}
