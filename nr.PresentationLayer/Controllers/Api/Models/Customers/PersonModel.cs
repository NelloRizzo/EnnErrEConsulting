using nr.PresentationLayer.Controllers.Api.Models.Customers.Addresses;
using nr.Utils;

namespace nr.PresentationLayer.Controllers.Api.Models.Customers
{
    /// <summary>
    /// Una persona.
    /// </summary>
    public class PersonModel : CustomerModel
    {
        internal static readonly string ModelType = nameof(PersonModel).ToCamelCase().Replace("Model", "");
        /// <summary>
        /// Nome.
        /// </summary>
        public required string FirstName { get; set; }
        /// <summary>
        /// Cognome.
        /// </summary>
        public required string LastName { get; set; }
        /// <summary>
        /// Nomignolo.
        /// </summary>
        public string? Nickname { get; set; }
        /// <summary>
        /// Indirizzo di residenza.
        /// </summary>
        public required PostalAddressModel BusinessAddress { get; set; }
    }
}
