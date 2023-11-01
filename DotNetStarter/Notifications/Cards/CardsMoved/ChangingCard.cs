namespace DotNetStarter.Notifications.Cards.CardsMoved
{
    public sealed class ChangingCard
    {
        public Guid Id { get; }

        public string Name { get; }

        public Guid StageId { get; }

        public ChangingCard(Guid id, string name, Guid stageId)
        {
            Id = id;
            Name = name;
            StageId = stageId;
        }
    }
}
