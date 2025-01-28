using nr.PresentationLayer.Controllers.Api.Models.Customers.Addresses;

namespace nr.PresentationLayer.Controllers.Api.Models.Customers
{
    /// <summary>
    /// Una persona.
    /// </summary>
    public class PersonModel
    {
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
        /// <summary>
        /// Eventuali indirizzi addizionali.
        /// </summary>
        public IEnumerable<AddressModel> AdditionalAddresses { get; set; } = [];
    }
}
