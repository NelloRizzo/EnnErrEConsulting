using System.ComponentModel.DataAnnotations;

namespace nr.BusinessLayer.Dto.Operators
{
    public class RoleDto : BaseDto
    {
        [Required(AllowEmptyStrings = false), MaxLength(20)]
        public required string RoleName { get; set; }
        public override int GetHashCode() => RoleName.GetHashCode();
    }
}
