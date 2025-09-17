using nr.Utils;
using System.ComponentModel.DataAnnotations;

namespace nr.Validation
{
    /// <summary>
    /// Valida un codice fiscale italiano.
    /// </summary>
    /// <remarks>Non valida il campo se <strong>null</strong>.</remarks>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class FiscalCodeAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) {
            if (IsValid(value)) return ValidationResult.Success;

            return new ValidationResult(ErrorMessage ?? $"Field {validationContext.MemberName!} must be a valid italian fiscal code");
        }
        public override bool IsValid(object? value) => value == null || value is string fc && fc.IsFiscalCode();
    }
}
