using DotNetStarter.Entities;
using MediatR;

namespace DotNetStarter.Queries.Cards.Get
{
    public sealed class GetCard : IRequest<Card>
    {
        public Guid? ProjectManagerId { get; }

        public Guid CardId { get; }

        public Guid ProjectId { get; }

        public GetCard(Guid? projectManagerId, Guid cardId, Guid projectId)
        {
            ProjectManagerId = projectManagerId;
            CardId = cardId;
            ProjectId = projectId;
        }
    }
}
