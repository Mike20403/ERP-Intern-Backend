namespace DotNetStarter.Services.Email
{
    public class FileAttachmentInfo
    {
        public byte[] Data { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
    }
}
