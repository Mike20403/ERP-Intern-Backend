using MediatR;

namespace DotNetStarter.Commands.Projects.Delete
{
    public sealed class DeleteProject : IRequest
    {
        public Guid AgencyMemberId { get; }

        public Guid ProjectId { get; }

        public DeleteProject(Guid agencyMemberId, Guid projectId)
        {
            AgencyMemberId = agencyMemberId;
            ProjectId = projectId;
        }
    }
}
