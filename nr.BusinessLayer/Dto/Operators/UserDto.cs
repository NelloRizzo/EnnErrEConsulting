using System.ComponentModel.DataAnnotations;

namespace nr.BusinessLayer.Dto.Operators
{
    public class UserDto : BaseDto
    {
        [Required(AllowEmptyStrings = false), MaxLength(80)]
        public required string Email { get; set; }
        [Required(AllowEmptyStrings = false), MaxLength(125)]
        public required string Password { get; set; }
        public IEnumerable<string> Roles { get; set; } = [];
        public override int GetHashCode() => Email.GetHashCode();
    }
}
