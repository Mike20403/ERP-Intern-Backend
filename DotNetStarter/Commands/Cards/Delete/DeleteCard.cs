using DotNetStarter.Common.Models;
using DotNetStarter.Entities;
using MediatR;

namespace DotNetStarter.Commands.Cards.Delete
{
    public sealed class DeleteCard : IRequest<List<DataChanged<Card>>>
    {
        public Guid? ProjectManagerId { get; }

        public Guid CardId { get; }

        public Guid ProjectId { get; }

        public DeleteCard(Guid? projectManagerId, Guid cardId, Guid projectId)
        {
            ProjectManagerId = projectManagerId;
            CardId = cardId;
            ProjectId = projectId;
        }
    }
}
