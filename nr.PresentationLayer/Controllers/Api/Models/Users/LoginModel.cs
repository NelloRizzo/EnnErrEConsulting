using System.ComponentModel.DataAnnotations;

namespace nr.PresentationLayer.Controllers.Api.Models.Users
{
    /// <summary>
    /// Modello di login.
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// Username.
        /// </summary>
        [Required(AllowEmptyStrings = false), EmailAddress]
        public required string Username { get; set; }
        [Required(AllowEmptyStrings = false), StringLength(20)]
        /// <summary>
        /// Password.
        /// </summary>
        public required string Password { get; set; }
    }
}
