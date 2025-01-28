using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nr.BusinessLayer.EF.DataLayer.Entities.Operators
{
    /// <summary>
    /// Tabella dei ruoli.
    /// </summary>
    [Table("Roles")]
    [Index(nameof(RoleName), IsUnique = true, Name = "IDX_ROLE_UNIQUE")]
    public class RoleEntity
    {
        /// <summary>
        /// Chiave.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Nome del ruolo.
        /// </summary>
        [Required(AllowEmptyStrings = false), MaxLength(20)]
        public required string RoleName { get; set; }
    }
}
