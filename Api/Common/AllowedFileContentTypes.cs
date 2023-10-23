using System.ComponentModel.DataAnnotations;

public class AllowedFileContentTypesAttribute : ValidationAttribute
{
    private readonly string[] _allowedContentTypes;

    public AllowedFileContentTypesAttribute(string[] allowedContentTypes)
    {
        _allowedContentTypes = allowedContentTypes;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is IFormFile file)
        {
            if (!_allowedContentTypes.Contains(file.ContentType, StringComparer.OrdinalIgnoreCase))
            {
                return new ValidationResult($"Only the following content types are allowed: {string.Join(", ", _allowedContentTypes)}");
            }
        }

        return ValidationResult.Success;
    }
}
