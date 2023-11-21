using DotNetStarter.Common.Models;
using DotNetStarter.Entities;
using MediatR;

namespace DotNetStarter.Commands.Attachments.Delete
{
    public sealed class DeleteAttachment : IRequest<DataChanged<Attachment>>
    {
        public Guid? ProjectManagerId { get; }

        public Guid? TalentId { get; }

        public Guid AttachmentId { get; }

        public Guid ProjectId { get; }

        public Guid CardId { get; }

        public DeleteAttachment(Guid? projectManagerId, Guid? talentId, Guid attachmentId, Guid projectId, Guid cardId)
        {
            ProjectManagerId = projectManagerId;
            TalentId = talentId;
            AttachmentId = attachmentId;
            ProjectId = projectId;
            CardId = cardId;
        }
    }
}
