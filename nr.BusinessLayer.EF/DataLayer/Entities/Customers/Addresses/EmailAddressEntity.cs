using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nr.BusinessLayer.EF.DataLayer.Entities.Customers.Addresses
{
    [Table("Emails")]
    public class EmailAddressEntity : AddressEntity
    {
        [Required, EmailAddress, MaxLength(80)]
        public required string Email { get; set; }
    }
}
