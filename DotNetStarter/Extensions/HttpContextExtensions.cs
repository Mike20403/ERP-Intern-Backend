using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace DotNetStarter.Extensions
{
    public static class HttpContextExtensions
    {
        public const string PrivilegesClaimName = "privileges";

        public static string GetIpAddress(this HttpContext @this)
        {
            try
            {
                var address = @this.Connection.RemoteIpAddress;
                return address!.ToString();
            }
            catch
            {
                return "localhost";
            }
        }

        public static Guid? GetCurrentUserId(this HttpContext @this)
        {
            var userId = @this?.User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId is not null && Guid.TryParse(userId, out Guid id))
            {
                return id;
            }

            return null;
        }

        public static string? GetCurrentUserRole(this HttpContext @this) => @this?.User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

        public static string? GetCurrentUserEmail(this HttpContext @this) => @this?.User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

        public static List<string> GetCurrentUserPrivileges(this HttpContext @this) => @this?.User?.Claims?.Where(c => c.Type == PrivilegesClaimName)?.Select(claim => claim.Value).ToList() ?? new List<string>();
    }
}
