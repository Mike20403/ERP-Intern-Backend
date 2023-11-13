using DotNetStarter.Common.Models;
using DotNetStarter.Entities;
using MediatR;

namespace DotNetStarter.Commands.Comments.Delete
{
    public sealed class DeleteComment : IRequest<List<DataChanged<Comment>>>
    {
        public Guid ProjectId { get; }

        public Guid CardId { get; }

        public Guid CommentId { get; }

        public Guid OwnerId { get; }

        public DeleteComment(Guid projectId, Guid cardId, Guid commentId, Guid ownerId)
        {
            ProjectId = projectId;
            CardId = cardId;
            CommentId = commentId;
            OwnerId = ownerId;
        }
    }
}
