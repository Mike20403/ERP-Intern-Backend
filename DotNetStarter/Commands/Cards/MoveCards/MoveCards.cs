using DotNetStarter.Common.Models;
using MediatR;

namespace DotNetStarter.Commands.Cards.MoveCards
{
    public sealed class MoveCards : IRequest<List<DataChanged<MovingCard>>>
    {
        public List<MovingCard> Cards { get; }

        public Guid ProjectId { get; }

        public Guid? ProjectManagerId { get; }

        public MoveCards(List<MovingCard> cards, Guid projectId, Guid? projectManagerId)
        {
            Cards = cards;
            ProjectId = projectId;
            ProjectManagerId = projectManagerId;
        }
    }
}
