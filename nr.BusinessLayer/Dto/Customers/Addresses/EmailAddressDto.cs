using System.ComponentModel.DataAnnotations;

namespace nr.BusinessLayer.Dto.Customers.Addresses
{
    /// <summary>
    /// Un indirizzo email.
    /// </summary>
    public class EmailAddressDto : AddressDto
    {
        /// <summary>
        /// L'indirizzo email.
        /// </summary>
        [Required, EmailAddress, MaxLength(80)]
        public required string Email { get; set; }
    }
}
