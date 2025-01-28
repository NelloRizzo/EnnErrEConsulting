using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace nr.Validation
{
    /// <summary>
    /// Aggiunge una proprietà <strong>IsValid</strong> che procede alla validazione sulla base di tutti i <strong>ValidationAttribute</strong> presenti nei suoi attributi.
    /// </summary>
    /// <seealso cref="ValidationAttribute"/>
    public interface IValidatable
    {
        /// <summary>
        /// Controlla la validità di tutte le proprietà alle quali sono associati attributi di tipo <strong>ValidationAttribute</strong>.
        /// </summary>
        public virtual bool IsValid =>
            GetType().GetCustomAttributes<ValidationAttribute>().All(a => a.IsValid(this))
            &&
            GetType().GetProperties()
                .All(p => p.GetCustomAttributes<ValidationAttribute>().All(a => a.IsValid(p.GetValue(this)))
        );
    }

    /// <summary>
    /// Helpers per l'uso dell'interfaccia <strong>IValidatable</strong>.
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        /// Metodo di estensione che richiama la proprietà <strong>IsValid</strong> sull'entità.
        /// </summary>
        /// <param name="entity">Entità da validare.</param>
        /// <returns>Il risultato della valutazione della proprietà <strong>IsValid</strong> dell'entità.</returns>
        /// <see cref="IValidatable"/>
        public static bool IsValid(this IValidatable entity) => entity.IsValid;
    }
}
