using DotNetStarter.Common.Models;
using DotNetStarter.Entities;
using MediatR;

namespace DotNetStarter.Commands.Cards.RemoveOwner
{
    public sealed class RemoveOwner : IRequest<DataChanged<Talent>>
    {
        public Guid ProjectId { get; }

        public Guid CardId { get; }

        public Guid OwnerId { get; }

        public Guid? ProjectManagerId { get; }

        public Guid? TalentId { get; }

        public RemoveOwner(Guid projectId, Guid cardId, Guid ownerId, Guid? projectManagerId, Guid? talentId)
        {
            ProjectId = projectId;
            CardId = cardId;
            OwnerId = ownerId;
            ProjectManagerId = projectManagerId;
            TalentId = talentId;
        }
    }
}
