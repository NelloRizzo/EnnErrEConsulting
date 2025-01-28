using nr.BusinessLayer.EF.DataLayer.Entities.Customers.Addresses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nr.BusinessLayer.EF.DataLayer.Entities.Customers
{
    [Table("Customers")]
    public class CustomerEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int BusinessAddressId { get; set; }
        [ForeignKey(nameof(BusinessAddressId))]
        public virtual required PostalAddressEntity BusinessAddress { get; set; }
        public virtual IList<AddressEntity> Addresses { get; set; } = [];
    }
}
