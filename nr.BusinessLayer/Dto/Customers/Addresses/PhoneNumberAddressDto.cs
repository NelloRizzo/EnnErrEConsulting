using System.ComponentModel.DataAnnotations;

namespace nr.BusinessLayer.Dto.Customers.Addresses
{
    /// <summary>
    /// Un numero di telefono.
    /// </summary>
    public class PhoneNumberAddressDto : AddressDto
    {
        /// <summary>
        /// Il numero di telefono.
        /// </summary>
        [Required, Phone, MaxLength(20)]
        public required string PhoneNumber { get; set; }
    }
}
