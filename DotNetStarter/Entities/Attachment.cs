using System.ComponentModel.DataAnnotations;

namespace DotNetStarter.Entities
{
    public class Attachment : BaseAuditingEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string OriginalName { get; set; }

        [Required]
        public Guid CardId { get; set; }

        public Card? Card { get; set; }
    }
}
