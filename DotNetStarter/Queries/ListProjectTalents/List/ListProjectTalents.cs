using DotNetStarter.Entities;
using MediatR;

namespace DotNetStarter.Queries.TalentsOfAProject.List
{
    public sealed class ListProjectTalents : IRequest<List<User>>
    {
        public Guid? AgencyMemberId { get; }

        public Guid? ProjectManagerId { get; }

        public Guid? TalentId { get; }

        public Guid ProjectId { get; }

        public ListProjectTalents(Guid? agencyMemberId, Guid? projectManagerId, Guid? talentId, Guid projectId)
        {
            AgencyMemberId = agencyMemberId;
            ProjectManagerId = projectManagerId;
            TalentId = talentId;
            ProjectId = projectId;
        }
    }
}
