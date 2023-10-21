using MediatR;

namespace DotNetStarter.Commands.Attachments.Delete
{
    public sealed class DeleteAttachment : IRequest
    {
        public Guid? ProjectManagerId { get; }

        public Guid AttachmentId { get; }

        public Guid ProjectId { get; }

        public Guid CardId { get; }

        public DeleteAttachment(Guid? projectManagerId, Guid attachmentId, Guid projectId, Guid cardId)
        {
            ProjectManagerId = projectManagerId;
            AttachmentId = attachmentId;
            ProjectId = projectId;
            CardId = cardId;
        }
    }
}
