namespace nr.PresentationLayer.Controllers.Api.Models.Users
{
    /// <summary>
    /// Dati utente.
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// Email (username).
        /// </summary>
        public required string Email { get; set; }
        /// <summary>
        /// Ruoli associati.
        /// </summary>
        public string? Roles { get; set; }
    }
}
