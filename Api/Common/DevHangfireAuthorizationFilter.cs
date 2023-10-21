using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace Api.Common
{
    public sealed class DevHangfireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context) => true;
    }
}
