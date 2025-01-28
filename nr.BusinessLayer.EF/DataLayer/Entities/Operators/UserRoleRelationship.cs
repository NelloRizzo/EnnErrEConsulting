using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace nr.BusinessLayer.EF.DataLayer.Entities.Operators
{
    /// <summary>
    /// Tabella di collegamento utenti/ruoli.
    /// </summary>
    [Table("UsersRoles")]
    [PrimaryKey(nameof(UserId), nameof(RoleId))]
    public class UserRoleRelationship
    {
        /// <summary>
        /// Chiave dell'utente.
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Chiave dei ruoli.
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// Utente.
        /// </summary>
        [ForeignKey(nameof(UserId))]
        public virtual required UserEntity User { get; set; }
        /// <summary>
        /// Ruolo.
        /// </summary>
        [ForeignKey(nameof(RoleId))]
        public virtual required RoleEntity Role { get; set; }
    }
}