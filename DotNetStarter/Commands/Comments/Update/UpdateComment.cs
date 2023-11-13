using DotNetStarter.Common.Enums;
using DotNetStarter.Common.Models;
using DotNetStarter.Entities;
using MediatR;

namespace DotNetStarter.Commands.Comments.Update
{
    public sealed class UpdateComment : IRequest<DataChanged<Comment>>
    {
        public Guid ProjectId { get; }

        public Guid CardId { get; }

        public Guid CommentId { get; }

        public string Description { get; }

        public CommentStatus CommentStatus { get; }

        public Guid OwnerId { get; }

        public UpdateComment(Guid projectId, Guid cardId, Guid commentId, string description, CommentStatus commentStatus, Guid ownerId)
        {
            ProjectId = projectId;
            CardId = cardId;
            CommentId = commentId;
            Description = description;
            CommentStatus = commentStatus;
            OwnerId = ownerId;
        }
    }
}
