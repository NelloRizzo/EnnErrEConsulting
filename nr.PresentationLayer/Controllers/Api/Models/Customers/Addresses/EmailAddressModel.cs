using System.ComponentModel.DataAnnotations;

namespace nr.PresentationLayer.Controllers.Api.Models.Customers.Addresses
{
    /// <summary>
    /// Indirizzo email.
    /// </summary>
    public class EmailAddressModel : AddressModel
    {
        /// <summary>
        /// L'indirizzo.
        /// </summary>
        [Required, EmailAddress, MaxLength(80)]
        public required string Email { get; set; }
    }
}
