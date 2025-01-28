using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nr.BusinessLayer.EF.DataLayer.Entities.Operators
{
    /// <summary>
    /// Tabella degli utenti.
    /// </summary>
    [Table("Users")]
    [Index(nameof(Email), IsUnique = true, Name = "IDX_USERNAME_UNIQUE")]
    public class UserEntity
    {
        /// <summary>
        /// Chiave.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Email.
        /// </summary>
        /// <remarks>Funziona da username univoco.</remarks>
        [Required(AllowEmptyStrings = false), MaxLength(80)]
        public required string Email { get; set; }
        /// <summary>
        /// Password.
        /// </summary>
        [Required(AllowEmptyStrings = false), MaxLength(125)]
        public required string Password { get; set; }
        /// <summary>
        /// Elenco dei ruoli collegati.
        /// </summary>
        public virtual IList<UserRoleRelationship> Roles { get; set; } = [];
    }
}
