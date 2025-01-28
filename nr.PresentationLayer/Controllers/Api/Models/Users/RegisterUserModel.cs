using System.ComponentModel.DataAnnotations;

namespace nr.PresentationLayer.Controllers.Api.Models.Users
{
    public class RegisterUserModel
    {
        [Required(AllowEmptyStrings = false), MaxLength(80)]
        public required string Email { get; set; }
        [Required(AllowEmptyStrings = false), MaxLength(15)]
        public required string Password { get; set; }
        [Compare(nameof(Password))]
        public required string ComparePassword { get; set; }
        [MaxLength(80), RegularExpression(@"(([a-z]+),)*([a-z]+)")]
        public string? Roles { get; set; }
    }
}