using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Api.Hubs
{
    [Authorize(Roles = $"{RoleNames.ProjectManager},{RoleNames.Talent}")]
    public class ProjectHub : Hub<IProjectClient>
    {
        public async Task SubcribeToProject(Guid projectId, IDotNetStarterUnitOfWork unitOfWork)
        {
            var projectMemberId = Context.GetHttpContext()?.GetCurrentUserId();
            var isProjectMember = await unitOfWork.ProjectRepository
                .AnyAsync(filter: p => p.Id == projectId && (p.ProjectManagerId == projectMemberId || p.Talents!.Any(t => t.Id == projectMemberId)));

            if (isProjectMember)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, projectId.ToProjectGroup());
            }
        }

        public async Task UnsubcribeFromProject(Guid projectId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, projectId.ToProjectGroup());
        }
    }
}
