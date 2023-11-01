using MediatR;

namespace DotNetStarter.Notifications.Cards.CardCreated
{
    public sealed class CardCreated : INotification
    {
        public Guid CardId { get; }

        public Guid ProjectId { get; }

        public Guid StageId { get; }

        public CardCreated(Guid cardId, Guid projectId, Guid stageId)
        {
            CardId = cardId;
            ProjectId = projectId;
            StageId = stageId;
        }
    }
}
