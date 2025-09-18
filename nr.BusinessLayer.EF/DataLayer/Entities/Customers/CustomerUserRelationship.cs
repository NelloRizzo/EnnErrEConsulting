using nr.BusinessLayer.EF.DataLayer.Entities.Operators;
using System.ComponentModel.DataAnnotations.Schema;

namespace nr.BusinessLayer.EF.DataLayer.Entities.Customers
{
    [Table("CustomersUsers")]
    public class CustomerUserRelationship
    {
        public int UserId { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual required UserEntity User { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public virtual required CustomerEntity Customer { get; set; }
    }
}
