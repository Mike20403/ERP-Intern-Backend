using DotNetStarter.Common.Enums;
using DotNetStarter.Entities;

namespace DotNetStarter.Queries.Projects.List
{
    public sealed class ListProjects : ListRequest<Project>
    {
        public Guid? AgencyMemberId { get; }

        public Guid? ProjectManagerId { get; }

        public Guid? TalentId { get; }

        public ProjectStatus? Status { get; }

        public ListProjects
        (
            int pageNumber, 
            int pageSize, 
            string? searchQuery, 
            string? orderBy, 
            Guid? agencyMemberId, 
            Guid? projectManagerId, 
            Guid? talentId,
            ProjectStatus? status
        ) : base(pageNumber, pageSize, searchQuery, orderBy)
        {
            AgencyMemberId = agencyMemberId;
            ProjectManagerId = projectManagerId;
            TalentId = talentId;
            Status = status;
        }
    }
}