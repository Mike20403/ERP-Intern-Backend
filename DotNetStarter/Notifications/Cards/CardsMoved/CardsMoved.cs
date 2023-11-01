using MediatR;

namespace DotNetStarter.Notifications.Cards.CardsMoved
{
    public sealed class CardsMoved : INotification
    {
        public Guid ProjectId { get; }

        public List<ChangingCard> OldCards { get; }

        public List<ChangingCard> NewCards { get; }

        public CardsMoved(Guid projectId, List<ChangingCard> oldCards, List<ChangingCard> newCards)
        {
            ProjectId = projectId;
            OldCards = oldCards;
            NewCards = newCards;
        }
    }
}
