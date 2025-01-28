using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nr.BusinessLayer.EF.DataLayer.Entities.Operators
{
    [Table("Users")]
    [Index(nameof(Email), IsUnique = true, Name = "IDX_USERNAME_UNIQUE")]
    public class UserEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false), MaxLength(80)]
        public required string Email { get; set; }
        [Required(AllowEmptyStrings = false), MaxLength(125)]
        public required string Password { get; set; }
        public virtual IList<UserRoleRelationship> Roles { get; set; } = [];
    }
}
