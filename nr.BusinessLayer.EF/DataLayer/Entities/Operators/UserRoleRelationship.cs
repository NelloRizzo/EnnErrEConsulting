using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace nr.BusinessLayer.EF.DataLayer.Entities.Operators
{
    [Table("UsersRoles")]
    [PrimaryKey(nameof(UserId), nameof(RoleId))]
    public class UserRoleRelationship
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual required UserEntity User { get; set; }
        [ForeignKey(nameof(RoleId))]
        public virtual required RoleEntity Role { get; set; }
    }
}