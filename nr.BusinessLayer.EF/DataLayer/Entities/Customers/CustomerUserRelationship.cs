using nr.BusinessLayer.EF.DataLayer.Entities.Operators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nr.BusinessLayer.EF.DataLayer.Entities.Customers
{
    public class CustomerUserRelationship
    {
        public int UserId {  get; set; }
        public int CustomerId {  get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual required UserEntity User { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public virtual required CustomerEntity Customer { get; set; }
    }
}
