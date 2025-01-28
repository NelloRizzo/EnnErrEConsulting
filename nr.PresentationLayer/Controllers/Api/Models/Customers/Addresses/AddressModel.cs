using nr.PresentationLayer.Controllers.Api.JsonConverters;
using System.Text.Json.Serialization;

namespace nr.PresentationLayer.Controllers.Api.Models.Customers.Addresses
{
    /// <summary>
    /// Modello di base per gli indirizzi.
    /// </summary>
    [JsonConverter(typeof(AddressModelConverter))]
    public abstract class AddressModel
    {
        /// <summary>
        /// Indica se si tratta di un indirizzo di lavoro.
        /// </summary>
        public bool IsBusiness { get; set; }
        /// <summary>
        /// Discriminante di tipo per serializzazione e deserializzazione JSON.
        /// </summary>
        public string? Type { get; set; }
    }
}