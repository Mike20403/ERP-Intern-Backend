using DotNetStarter.Entities;
using MediatR;

namespace DotNetStarter.Queries.Projects.Get
{
    public sealed class GetProject : IRequest<Project>
    {
        public Guid? AgencyMemberId { get; }

        public Guid? ProjectManagerId { get; }

        public Guid ProjectId { get; }

        public GetProject(Guid? agencyMemberId, Guid? projectManagerId, Guid projectId)
        {
            AgencyMemberId = agencyMemberId;
            ProjectManagerId = projectManagerId;
            ProjectId = projectId;
        }
    }
}
