using System.ComponentModel.DataAnnotations;

namespace nr.PresentationLayer.Controllers.Api.Models.Users
{
    /// <summary>
    /// Modello per la registrazione di un utente.
    /// </summary>
    public class RegisterUserModel
    {
        /// <summary>
        /// Email.
        /// </summary>
        [Required(AllowEmptyStrings = false), MaxLength(80)]
        public required string Email { get; set; }
        /// <summary>
        /// Password.
        /// </summary>
        [Required(AllowEmptyStrings = false), MaxLength(15)]
        public required string Password { get; set; }
        /// <summary>
        /// Conferma della password.
        /// </summary>
        [Compare(nameof(Password))]
        public required string ComparePassword { get; set; }
        /// <summary>
        /// Ruoli ai quali associare l'utente.
        /// </summary>
        [MaxLength(80), RegularExpression(@"(([a-z]+),)*([a-z]+)")]
        public string? Roles { get; set; }
    }
}