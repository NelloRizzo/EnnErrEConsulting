using System.ComponentModel.DataAnnotations;

namespace nr.PresentationLayer.Controllers.Api.Models.Customers.Addresses
{
    public class PhoneNumberAddressModel : AddressModel
    {
        [Required, Phone, MaxLength(20)]
        public required string PhoneNumber { get; set; }
    }
}
