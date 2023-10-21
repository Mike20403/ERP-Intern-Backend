using System.ComponentModel.DataAnnotations;

public class AllowedFileExtensionsAttribute : ValidationAttribute
{
    private readonly string[] _allowedExtensions;

    public AllowedFileExtensionsAttribute(string[] allowedExtensions)
    {
        _allowedExtensions = allowedExtensions;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is IFormFile file)
        {
            var fileExtension = Path.GetExtension(file.FileName).Replace(".", "").ToLower();

            if (!_allowedExtensions.Contains(fileExtension))
            {
                return new ValidationResult($"Only the following file types are allowed: {string.Join(", ", _allowedExtensions)}");
            }
        }

        return ValidationResult.Success;
    }
}
