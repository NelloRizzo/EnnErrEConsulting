namespace nr.PresentationLayer.Controllers.Api.Models.Users
{
    public class UserModel
    {
        public required string Email { get; set; }
        public string? Roles { get; set; }
    }
}
