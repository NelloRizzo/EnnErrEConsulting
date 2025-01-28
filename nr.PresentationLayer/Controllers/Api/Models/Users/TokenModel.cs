namespace nr.PresentationLayer.Controllers.Api.Models.Users
{
    /// <summary>
    /// Token JWT.
    /// </summary>
    public class TokenModel
    {
        /// <summary>
        /// Token.
        /// </summary>
        public required string Token { get; set; }
        /// <summary>
        /// Username.
        /// </summary>
        public required string Username { get; set; }
        /// <summary>
        /// Ruoli associati all'utente.
        /// </summary>
        public virtual IEnumerable<string> Roles { get; set; } = [];
    }
}
