namespace DotNetStarter.Commands.Stages.Update
{
    public sealed class UpsertStage
    {
        public Guid? Id { get; }

        public string Name { get; }

        public bool IsNotificationEnabled { get;}

        public UpsertStage(Guid? id, string name, bool isNotificationEnabled)
        {
            Id = id;
            Name = name;
            IsNotificationEnabled = isNotificationEnabled;
        }
    }
}
