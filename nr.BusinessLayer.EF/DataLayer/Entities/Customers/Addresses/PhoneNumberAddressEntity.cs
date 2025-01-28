using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nr.BusinessLayer.EF.DataLayer.Entities.Customers.Addresses
{
    [Table("PhoneNumbers")]
    public class PhoneNumberAddressEntity : AddressEntity
    {
        [Required, Phone, MaxLength(20)]
        public required string PhoneNumber { get; set; }
    }
}
