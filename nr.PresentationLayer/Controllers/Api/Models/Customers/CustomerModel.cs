using nr.PresentationLayer.Controllers.Api.Models.Customers.Addresses;
using nr.PresentationLayer.Controllers.Api.Models.Users;
using System.Text.Json.Serialization;

namespace nr.PresentationLayer.Controllers.Api.Models.Customers
{
    //[JsonConverter(typeof(CustomerModelConverter))]
    [JsonDerivedType(typeof(PersonModel), "person")]
    [JsonDerivedType(typeof(CompanyModel), "company")]
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
        public IEnumerable<UserModel> Users { get; set; } = [];
        ///// <summary>
        ///// Discriminante di tipo.
        ///// </summary>
        //public required string Type { get; set; }
        /// <summary>
        /// Nome visualizzato.
        /// </summary>
        public string? DisplayName { get; set; }
    }
}
