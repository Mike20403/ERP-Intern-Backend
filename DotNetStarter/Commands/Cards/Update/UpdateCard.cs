using DotNetStarter.Common.Models;
using DotNetStarter.Entities;
using MediatR;

namespace DotNetStarter.Commands.Cards.Update
{
    public sealed class UpdateCard : IRequest<DataChanged<Card>>
    {
        public Guid? ProjectManagerId { get; }

        public Guid CardId { get; }

        public string Name { get; }

        public string Description { get; }

        public Guid ProjectId { get; }

        public UpdateCard(Guid? projectManagerId, Guid cardId, string name, string description, Guid projectId)
        {
            ProjectManagerId = projectManagerId;
            CardId = cardId;
            Name = name;
            Description = description;
            ProjectId = projectId;
        }
    }
}
