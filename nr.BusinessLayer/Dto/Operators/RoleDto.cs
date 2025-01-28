using System.ComponentModel.DataAnnotations;

namespace nr.BusinessLayer.Dto.Operators
{
    /// <summary>
    /// Un ruolo.
    /// </summary>
    public class RoleDto : BaseDto
    {
        /// <summary>
        /// Nome del ruolo.
        /// </summary>
        [Required(AllowEmptyStrings = false), MaxLength(20)]
        public required string RoleName { get; set; }
        /// <inheritdoc/>
        public override int GetHashCode() => RoleName.GetHashCode();
    }
}
