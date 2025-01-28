using System.ComponentModel.DataAnnotations;

namespace nr.BusinessLayer.Dto.Customers.Addresses
{
    public class EmailAddressDto : AddressDto
    {
        [Required, EmailAddress, MaxLength(80)]
        public required string Email { get; set; }
    }
}
