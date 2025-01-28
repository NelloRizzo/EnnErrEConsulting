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
        public override bool IsValid(object? value) => value == null || (value is string fc && fc.IsFiscalCode());
    }
}
