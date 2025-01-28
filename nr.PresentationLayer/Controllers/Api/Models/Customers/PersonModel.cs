using nr.PresentationLayer.Controllers.Api.Models.Customers.Addresses;

namespace nr.PresentationLayer.Controllers.Api.Models.Customers
{
    public class PersonModel
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Nickname { get; set; }
        public required PostalAddressModel BusinessAddress { get; set; }
        public IEnumerable<AddressModel> AdditionalAddresses { get; set; } = [];
    }
}
