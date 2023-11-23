using DotNetStarter.Common;
using DotNetStarter.Extensions;
using DotNetStarter.Notifications.Users.ExportTalentRequested;

namespace DotNetStarter.Commands.Talents.Export
{
    public sealed class ExportTalentHandler : BaseRequestHandler<ExportTalent>
    {
        public ExportTalentHandler(IServiceProvider serviceProvider) : base(serviceProvider) { }

        public override async Task Process(ExportTalent request, CancellationToken cancellationToken)
        {
            new ExportTalentRequested(
                request.AdministratorId,
                request.PageNumber,
                request.PageSize,
                request.SearchQuery,
                request.OrderBy,
                request.Gender,
                request.Status,
                request.IsAvailable
                ).Enqueue();
        }
    }
}
