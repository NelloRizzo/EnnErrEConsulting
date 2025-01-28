using System.ComponentModel.DataAnnotations;

namespace nr.BusinessLayer.Dto.Operators
{
    /// <summary>
    /// Un utente.
    /// </summary>
    public class UserDto : BaseDto
    {
        /// <summary>
        /// Indirizzo di posta elettronica.
        /// </summary>
        /// <remarks>Rappresenta lo username dell'utente.</remarks>
        [Required(AllowEmptyStrings = false), MaxLength(80)]
        public required string Email { get; set; }
        /// <summary>
        /// La password.
        /// </summary>
        [Required(AllowEmptyStrings = false), MaxLength(125)]
        public required string Password { get; set; }
        /// <summary>
        /// I ruoli ai quali l'utente è associato.
        /// </summary>
        public IEnumerable<string> Roles { get; set; } = [];
        /// <inheritdoc/>
        public override int GetHashCode() => Email.GetHashCode();
    }
}
