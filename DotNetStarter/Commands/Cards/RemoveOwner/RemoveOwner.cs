using DotNetStarter.Common.Models;
using DotNetStarter.Entities;
using MediatR;

namespace DotNetStarter.Commands.Cards.RemoveOwner
{
    public sealed class RemoveOwner : IRequest<DataChanged<Card>>
    {
        public Guid ProjectId { get; }

        public Guid CardId { get; }

        public Guid OwnerId { get; }

        public Guid? ProjectManagerId { get; }

        public RemoveOwner(Guid projectId, Guid cardId, Guid ownerId, Guid? projectManagerId)
        {
            ProjectId = projectId;
            CardId = cardId;
            OwnerId = ownerId;
            ProjectManagerId = projectManagerId;
        }
    }
}
