using System.ComponentModel.DataAnnotations;

namespace nr.Validation
{
    /// <summary>
    /// Controlla che nell'istanza ci sia almeno uno tra i campi elencati diverso da <strong>null</strong>.
    /// </summary>
    /// <param name="fields">Elenco dei campi tra i quali controllare.</param>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class AtLeastOneAttribute(params string[] fields) : ValidationAttribute
    {
        private readonly string[] _fields = fields;
        public override bool IsValid(object? value) =>
            value?.GetType().GetProperties()
                .Where(p => _fields.Contains(p.Name, StringComparer.InvariantCultureIgnoreCase))
                .Any(p => p.GetValue(value) != null) ?? false;
    }
}


