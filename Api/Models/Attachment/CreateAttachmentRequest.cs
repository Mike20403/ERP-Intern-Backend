namespace Api.Models.Attachment
{
    public class CreateAttachmentRequest
    {
        [AllowedFileExtensions(new[] { "jpg", "jpeg", "png", "pdf", "txt" })]
        public IFormFile? File { get; set; }
    }
}
