using DotNetStarter.Common.Enums;

namespace Api.Dtos
{
    public class CommentDto
    {
        public Guid CardId { get; set; }

        public Guid? ParentId { get; set; }

        public Guid? Id { get; set; }

        public string Description { get; set; }

        public CommentStatus CommentStatus { get; set; }

        public PersonDto? User { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
