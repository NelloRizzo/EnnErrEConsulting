using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace nr.Validation
{
    /// <summary>
    /// Verifica che una collezione non presenti un determinato valore.
    /// </summary>
    /// <param name="compareField">Nome del campo che contiene il valore di confronto che non deve essere presente nella collezione.</param>
    /// <param name="collectionField">Nome del campo che contiene la collezione.</param>
    /// <param name="innerProperty">Proprietà degli elementi della collezione da usare per discriminare l'uguaglianza.</param>
    /// <remarks>Se <strong>innerProperty</strong> è <em>null</em>, allora verrà usato il metodo <strong>Equals()</strong> 
    /// su ogni elemento della collezione per valutare l'uguaglianza, altrimenti sarà usato il metodo <strong>Equals()</strong> sulla proprietà
    /// denominata come specificato nel parametro <strong>innerProperty</strong>.</remarks>
    [AttributeUsage(AttributeTargets.Class)]
    public class NotContainsAttribute(string compareField, string collectionField, string? innerProperty = null) : ValidationAttribute()
    {
        public override bool IsValid(object? value) {
            var property = value!.GetType().GetProperty(compareField)!;
            var collection = value!.GetType().GetProperty(collectionField)!.GetValue(value);
            var compareValue = property!.GetValue(value)!;
            if (collection is IEnumerable v) {
                var found = false;
                var enumerator = v.GetEnumerator();
                while (!found && enumerator.MoveNext()) {
                    var i = enumerator.Current;
                    if (innerProperty != null)
                        found = i.GetType().GetProperty(innerProperty)!.GetValue(i)!.Equals(compareValue);
                    else
                        found = i.Equals(compareValue);
                }
                return !found;
            }
            return false;
        }
    }
}
