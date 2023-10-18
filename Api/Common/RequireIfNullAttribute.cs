using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace Api.Common
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RequiredIfNullAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public RequiredIfNullAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            var comparisonProperty = validationContext.ObjectType.GetProperty(_comparisonProperty) ??
                throw new ArgumentException($"Property {_comparisonProperty} not found.");

            var currentValue = value;
            var comparisonValue = comparisonProperty.GetValue(validationContext.ObjectInstance);

            return comparisonValue != null || currentValue != null
                ? ValidationResult.Success
                : new ValidationResult(ErrorMessage ?? $"This field is required because of {_comparisonProperty} is null");
        }
    }
}
