using DotNetStarter.Common.Enums;

namespace Api.Models.Comments
{
    public class ListCommentsQueryParams : ListQueryParams
    {
        public CommentStatus? Status { get; set; }

        public Guid? ParentId { get; set; }
    }
}
