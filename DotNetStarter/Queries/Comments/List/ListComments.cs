using DotNetStarter.Common.Enums;
using DotNetStarter.Entities;

namespace DotNetStarter.Queries.Comments.List
{
    public sealed class ListComments : ListRequest<Comment>
    {
        public Guid ProjectId { get; }

        public Guid CardId { get; }

        public Guid? ParentId { get; }

        public Guid? ProjectManagerId { get; }

        public Guid? TalentId { get; }

        public CommentStatus? Status { get; }

        public ListComments(
            int pageNumber,
            int pageSize,
            string? searchQuery,
            string? orderBy,
            Guid projectId,
            Guid cardId,
            Guid? parentId,
            Guid? projectManagerId,
            Guid? talentId,
            CommentStatus? status
            ) : base(pageNumber, pageSize, searchQuery, orderBy)
        {
            ProjectId = projectId;
            CardId = cardId;
            ParentId = parentId;
            ProjectManagerId = projectManagerId;
            TalentId = talentId;
            Status = status;
        }
    }
}
