using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nr.BusinessLayer.EF.DataLayer.Entities.Operators
{
    [Table("Roles")]
    [Index(nameof(RoleName), IsUnique = true, Name = "IDX_ROLE_UNIQUE")]
    public class RoleEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false), MaxLength(20)]
        public required string RoleName { get; set; }
    }
}
