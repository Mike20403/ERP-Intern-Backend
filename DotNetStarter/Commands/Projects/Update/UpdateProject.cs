using DotNetStarter.Common.Enums;
using DotNetStarter.Entities;
using MediatR;

namespace DotNetStarter.Commands.Projects.Update
{
    public sealed class UpdateProject : IRequest<Project>
    {
        public Guid AgencyMemberId { get; }

        public Guid ProjectId { get; }

        public string Name { get; }

        public ProjectStatus Status { get; }

        public UpdateProject(Guid agencyMemberId, Guid projectId, string name, ProjectStatus status)
        {
            AgencyMemberId = agencyMemberId;
            ProjectId = projectId;
            Name = name;
            Status = status;
        }
    }
}
