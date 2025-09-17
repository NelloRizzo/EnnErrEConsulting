using nr.Utils;
using System.ComponentModel.DataAnnotations;

namespace nr.Validation
{
    /// <summary>
    /// Controlla che un campo possa rappresentare una Partita IVA valida.
    /// </summary>
    /// <remarks>Non effettua la validazione se il campo è <strong>null</strong>.</remarks>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class VatCodeAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) {
            if (IsValid(value)) return ValidationResult.Success;

            return new ValidationResult(ErrorMessage ?? $"Field {validationContext.MemberName!} must be a valid italian VAT");
        }
        public override bool IsValid(object? value) => value == null || value is string fc && fc.IsVatCode();
    }
}
