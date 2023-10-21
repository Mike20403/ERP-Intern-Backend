namespace Api.Dtos
{
    public class AttachmentDto
    {
        public Guid? Id { get; set; }

        public string? Name { get; set; }

        public string? OriginalName { get; set; }

        public Guid? CardId { get; set; }
    }
}
