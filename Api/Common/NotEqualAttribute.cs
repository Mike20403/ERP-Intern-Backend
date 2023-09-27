using System.ComponentModel.DataAnnotations;

namespace Api.Common
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class NotEqualAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public NotEqualAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var currentValue = value as string;

            var comparisonProperty = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if (comparisonProperty == null)
            {
                throw new ArgumentException($"Property {_comparisonProperty} not found.");
            }

            var comparisonValue = comparisonProperty.GetValue(validationContext.ObjectInstance) as string;

            if (currentValue == comparisonValue)
            {
                return new ValidationResult(ErrorMessage ?? $"This field must not equal to {_comparisonProperty}");
            }

            return ValidationResult.Success;
        }
    }
}
