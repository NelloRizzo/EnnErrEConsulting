using System.ComponentModel.DataAnnotations;

namespace nr.PresentationLayer.Controllers.Api.Models.Customers.Addresses
{
    public class EmailAddressModel : AddressModel
    {
        [Required, EmailAddress, MaxLength(80)]
        public required string Email { get; set; }
    }
}
