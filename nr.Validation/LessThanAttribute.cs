using System.ComponentModel.DataAnnotations;

namespace nr.Validation
{
    /// <summary>
    /// Valuta la condizione che il campo <strong>compareField</strong> sia minore del campo <strong>targetField</strong>.
    /// </summary>
    /// <typeparam name="T">Tipo di dato da confrontare.</typeparam>
    /// <param name="compareField">Campo oggetto del confronto.</param>
    /// <param name="targetField">Campo con il quale effettuare il confronto.</param>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class LessThanAttribute<T>(string compareField, string targetField) : ValidationAttribute where T : IComparable<T>
    {
        public override bool IsValid(object? value) {
            if (value == null) return true;
            var p1 = value.GetType().GetProperties().Single(p => p.Name == compareField);
            var p2 = value.GetType().GetProperties().Single(p => p.Name == targetField);

            var v1 = p1.GetValue(value);
            var v2 = p2.GetValue(value);
            if (v1 == null || v2 == null) return true;
            return ((T)v1).CompareTo((T)v2) < 0;
        }
    }
}
