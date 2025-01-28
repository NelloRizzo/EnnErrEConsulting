using nr.Utils;
using nr.Validation;

namespace nr.BusinessLayer.Dto
{
    /// <summary>
    /// Dto di base.
    /// </summary>
    public class BaseDto : IValidatable
    {
        /// <summary>
        /// Chiave.
        /// </summary>
        public int Id { get; set; }
        /// <inheritdoc/>
        /// <remarks>L'uguaglianza è basata sul risultato del metodo <strong>GetHashCode()</strong>.</remarks>
        public override bool Equals(object? obj) => obj is BaseDto dto && dto.GetHashCode() == GetHashCode();
        /// <inheritdoc/>
        public override int GetHashCode() => Id;
        /// <inheritdoc/>

        public override string ToString() => this.Describe();
    }
}
