using System.Text.Json;

namespace DotNetStarter.Extensions
{
    public static class JsonSerializerExtensions
    {
        public static string SerializeWithCamelCase<T>(this T @this)
        {
            return JsonSerializer.Serialize(@this, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            });
        }

        public static T? DeserializeFromCamelCase<T>(this string @this)
        {
            return JsonSerializer.Deserialize<T>(@this, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            });
        }
    }
}
