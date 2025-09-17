using System.ComponentModel.DataAnnotations;

namespace nr.Validation
{
    /// <summary>
    /// Valuta la condizione che il campo <strong>compareField</strong> sia minore del campo <strong>targetField</strong>.
    /// </summary>
    /// <typeparam name="T">Tipo di dato da confrontare.</typeparam>
    /// <param name="compareField">Campo oggetto del confronto.</param>
    /// <param name="targetField">Campo con il quale effettuare il confronto.</param>
    /// <param name="evaluateEquals">Indica se considerare valida anche l'uguaglianza.</param>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class LessThanAttribute<T>(string compareField, string targetField, bool evaluateEquals = false) : ValidationAttribute where T : IComparable<T>
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) {
            if (value == null) return ValidationResult.Success;
            var p1 = value.GetType().GetProperties().Single(p => p.Name == compareField);
            var p2 = value.GetType().GetProperties().Single(p => p.Name == targetField);

            var v1 = p1.GetValue(value);
            var v2 = p2.GetValue(value);
            if (v1 == null || v2 == null)
                return ValidationResult.Success;
            var result = evaluateEquals ? ((T)v1).CompareTo((T)v2) <= 0 : ((T)v1).CompareTo((T)v2) < 0;
            if (result) return ValidationResult.Success;
            return new ValidationResult(ErrorMessage ?? $"The field {compareField} must be {(evaluateEquals ? "equals or" : "")} less than{targetField} field", [compareField]);
        }
    }
    /// <summary>
    /// Valuta la condizione che il campo <strong>compareField</strong> sia minore del campo <strong>targetField</strong>.
    /// </summary>
    /// <typeparam name="T">Tipo di dato da confrontare.</typeparam>
    /// <param name="compareField">Campo oggetto del confronto.</param>
    /// <param name="targetField">Campo con il quale effettuare il confronto.</param>
    /// <param name="evaluateEquals">Indica se considerare valida anche l'uguaglianza.</param>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class LessThanValueAttribute<T>(T? targetValue, bool evaluateEquals = false) : ValidationAttribute where T : IComparable<T>
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) {
            if (value == null || targetValue == null) return ValidationResult.Success;

            var result = evaluateEquals ? ((T)value).CompareTo(targetValue) <= 0 : ((T)value).CompareTo(targetValue) < 0;
            if (result) return ValidationResult.Success;
            return new ValidationResult(ErrorMessage ?? $"The field must be {(evaluateEquals ? "equals or" : "")} less than {targetValue} field", [validationContext.MemberName!]);
        }
    }
}
