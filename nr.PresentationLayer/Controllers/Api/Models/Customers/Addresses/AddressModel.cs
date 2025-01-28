using nr.PresentationLayer.Controllers.Api.JsonConverters;
using System.Text.Json.Serialization;

namespace nr.PresentationLayer.Controllers.Api.Models.Customers.Addresses
{
    [JsonConverter(typeof(AddressModelConverter))]
    public abstract class AddressModel
    {
        public bool IsBusiness { get; set; }
        public string? Type { get; set; }
    }
}