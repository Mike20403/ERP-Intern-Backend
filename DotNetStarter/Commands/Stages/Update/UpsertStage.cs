namespace DotNetStarter.Commands.Stages.Update
{
    public sealed class UpsertStage
    {
        public Guid? Id { get; }

        public string Name { get; }

        public UpsertStage(Guid? id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
