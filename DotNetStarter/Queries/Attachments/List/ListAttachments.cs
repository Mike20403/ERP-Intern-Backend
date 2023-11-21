using DotNetStarter.Entities;
using MediatR;

namespace DotNetStarter.Queries.Attachments.List
{
    public sealed class ListAttachments : IRequest<List<Attachment>>
    {
        public Guid? ProjectManagerId { get; }

        public Guid? TalentId { get; }

        public Guid CardId { get; }

        public Guid ProjectId { get; }

        public ListAttachments(Guid? projectManagerId, Guid? talentId, Guid cardId, Guid projectId)
        {
            ProjectManagerId = projectManagerId;
            TalentId = talentId;
            CardId = cardId;
            ProjectId = projectId;
        }
    }
}
