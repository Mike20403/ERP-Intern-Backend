using DotNetStarter.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.Comments
{
    public class UpdateCommentRequest
    {
        [Required]
        public string? Description { get; set; }

        [Required]
        public CommentStatus CommentStatus { get; set; }
    }
}
