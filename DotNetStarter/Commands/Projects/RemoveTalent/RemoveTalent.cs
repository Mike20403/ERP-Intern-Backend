using MediatR;

namespace DotNetStarter.Commands.Projects.RemoveTalent
{
    public sealed class RemoveTalent : IRequest
    {
        public Guid ProjectId { get; }

        public Guid TalentId { get; }

        public Guid? ProjectManagerId { get; }

        public Guid? AgencyMemberId { get; }

        public RemoveTalent(Guid projectId, Guid talentId, Guid? agencyMemberId, Guid? projectManagerId)
        {
            ProjectId = projectId;
            TalentId = talentId;
            AgencyMemberId = agencyMemberId;
            ProjectManagerId = projectManagerId;
        }
    }
}
