namespace nr.PresentationLayer.Controllers.Api.Models.Users
{
    public class TokenModel
    {
        public required string Token { get; set; }
        public required string Username { get; set; }
        public IEnumerable<string> Roles { get; set; } = [];
    }
}
