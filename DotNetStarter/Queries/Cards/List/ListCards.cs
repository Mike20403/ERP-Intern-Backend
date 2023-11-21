using DotNetStarter.Entities;
using MediatR;

namespace DotNetStarter.Queries.Cards.List
{
    public sealed class ListCards : IRequest<List<Card>>
    {
        public Guid? ProjectManagerId { get; }

        public Guid? TalentId { get; }

        public Guid ProjectId { get; }

        public ListCards(Guid? projectManagerId, Guid? talentId, Guid projectId)
        {
            ProjectManagerId = projectManagerId;
            TalentId = talentId;
            ProjectId = projectId;
        }
    }
}
