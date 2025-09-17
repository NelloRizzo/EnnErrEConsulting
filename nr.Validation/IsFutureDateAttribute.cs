using System.ComponentModel.DataAnnotations;

namespace nr.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class IsFutureDateAttribute(bool evaluateEquals = false) : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) {
            if (value == null) return ValidationResult.Success;

            if (value == null) return ValidationResult.Success;

            if (!(value is DateTime || value is DateOnly))
                return new ValidationResult(ErrorMessage ?? $"The field {validationContext.MemberName!} must be a date", [validationContext.MemberName!]);

            DateOnly compareValue = value is DateOnly only ? only : DateOnly.FromDateTime((DateTime)value);
            var now = DateOnly.FromDateTime(DateTime.Now);
            var result = evaluateEquals ? compareValue.CompareTo(now) >= 0 : compareValue.CompareTo(now) > 0;
            if (result) return ValidationResult.Success;
            return new ValidationResult(ErrorMessage ?? $"The field {validationContext.MemberName!} must be a future date", [validationContext.MemberName!]);
        }
    }
}
