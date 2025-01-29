using nr.PresentationLayer.Controllers.Api.JsonConverters;
using nr.PresentationLayer.Controllers.Api.Models.Customers.Addresses;
using System.Text.Json.Serialization;

namespace nr.PresentationLayer.Controllers.Api.Models.Customers
{
    [JsonConverter(typeof(CustomerModelConverter))]
    public class CustomerModel
    {
        /// <summary>
        /// Chiave.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Evenutali indirizzi addizionali.
        /// </summary>
        public IEnumerable<AddressModel> AdditionalAddresses { get; set; } = [];
        /// <summary>
        /// Discriminante di tipo.
        /// </summary>
        public required string Type { get; set; }
    }
}
