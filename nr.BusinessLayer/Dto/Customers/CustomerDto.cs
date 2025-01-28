using nr.BusinessLayer.Dto.Customers.Addresses;
using System.ComponentModel.DataAnnotations;

namespace nr.BusinessLayer.Dto.Customers
{
    public abstract class CustomerDto : BaseDto
    {
        public abstract string DisplayName { get; }
        [Required]
        public required PostalAddressDto BusinessAddress { get; set; }
        public IEnumerable<AddressDto> Addresses { get; set; } = [];
    }
}
