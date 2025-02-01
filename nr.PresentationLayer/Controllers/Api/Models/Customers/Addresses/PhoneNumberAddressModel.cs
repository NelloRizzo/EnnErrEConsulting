using nr.Utils;
using System.ComponentModel.DataAnnotations;

namespace nr.PresentationLayer.Controllers.Api.Models.Customers.Addresses
{
    /// <summary>
    /// Un numero di telefono.
    /// </summary>
    public class PhoneNumberAddressModel : AddressModel
    {
        /// <summary>
        /// Discriminante di tipo.
        /// </summary>
        internal static readonly string ModelType = nameof(PhoneNumberAddressModel).ToCamelCase().Replace("AddressModel", "");
        /// <summary>
        /// Il numero di telefono.
        /// </summary>
        [Required, Phone, MaxLength(20)]
        public required string PhoneNumber { get; set; }
    }
}
