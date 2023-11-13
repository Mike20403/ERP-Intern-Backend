using DotNetStarter.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetStarter.Entities
{
    public class Comment : BaseAuditingEntity
    {
        [Required]
        public CommentStatus CommentStatus { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public Guid CardId { get; set; }

        public Card? Card { get; set; }

        public Guid UserId { get; set; }

        public User? User { get; set; }

        public Guid? ParentId { get; set; }

        [ForeignKey(nameof(ParentId))]
        public Comment? Parent { get; set; }
    }
}
