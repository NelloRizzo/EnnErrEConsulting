using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nr.BusinessLayer.EF.DataLayer.Entities.Customers.Addresses
{
    /// <summary>
    /// Tabella dei numeri di telefono.
    /// </summary>
    [Table("PhoneNumbers")]
    public class PhoneNumberAddressEntity : AddressEntity
    {
        /// <summary>
        /// Il numero di telefono.
        /// </summary>
        [Required, Phone, MaxLength(20)]
        public required string PhoneNumber { get; set; }
    }
}
