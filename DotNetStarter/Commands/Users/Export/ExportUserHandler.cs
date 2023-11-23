using DotNetStarter.Common;
using DotNetStarter.Extensions;
using DotNetStarter.Notifications.Users.ExportUserRequested;

namespace DotNetStarter.Commands.Users.Export
{
    public sealed class ExportUserHandler : BaseRequestHandler<ExportUser>
    {
        public ExportUserHandler(IServiceProvider serviceProvider) : base(serviceProvider) { }

        public override async Task Process(ExportUser request, CancellationToken cancellationToken)
        {
            new ExportUserRequested(
                request.AdministratorId,
                request.PageNumber,
                request.PageSize,
                request.SearchQuery,
                request.OrderBy,
                request.RoleNames,
                request.Gender,
                request.Status).Enqueue();
        }
    }
}
