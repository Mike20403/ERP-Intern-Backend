using System.ComponentModel.DataAnnotations;

namespace Api.Models.Comments
{
    public class CreateCommentRequest
    {
        [Required]
        public string? Description { get; set; }

        public Guid? ParentId { get; set; }
    }
}
