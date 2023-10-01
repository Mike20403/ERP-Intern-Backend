using DotNetStarter.Common.Enums;
using DotNetStarter.Entities;

namespace DotNetStarter.Queries.Projects.List
{
    public sealed class ListProjects : ListRequest<Project>
    {
        public Guid? AgencyMemberId { get; }

        public Guid? ProjectManagerId { get; }

        public ProjectStatus? Status { get; }

        public ListProjects(Guid? agencyMemberId, Guid? projectManagerId, int pageNumber, int pageSize, string? searchQuery, ProjectStatus? status) : base(pageNumber, pageSize, searchQuery)
        {
            AgencyMemberId = agencyMemberId;
            ProjectManagerId = projectManagerId;
            Status = status;
        }
    }
}
