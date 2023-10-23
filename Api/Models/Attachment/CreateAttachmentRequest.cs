namespace Api.Models.Attachment
{
    public class CreateAttachmentRequest
    {
        [AllowedFileExtensions(new[] { "jpg", "jpeg", "png", "pdf", "txt" })]
        [AllowedFileContentTypes(new[] { "image/jpeg", "image/png", "application/pdf", "text/plain" })]
        public IFormFile? File { get; set; }
    }
}
