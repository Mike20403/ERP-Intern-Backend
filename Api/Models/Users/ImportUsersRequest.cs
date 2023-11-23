using System.ComponentModel.DataAnnotations;

namespace Api.Models.Users
{
    public class ImportUsersRequest
    {
        [AllowedFileExtensions(new[] { "csv" })]
        [Required]
        public IFormFile? File { get; set; }
    }
}
