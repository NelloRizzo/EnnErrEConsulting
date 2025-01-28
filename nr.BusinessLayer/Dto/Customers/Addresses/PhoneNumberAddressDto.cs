using System.ComponentModel.DataAnnotations;

namespace nr.BusinessLayer.Dto.Customers.Addresses
{
    public class PhoneNumberAddressDto : AddressDto
    {
        [Required, Phone, MaxLength(20)]
        public required string PhoneNumber { get; set; }
    }
}
