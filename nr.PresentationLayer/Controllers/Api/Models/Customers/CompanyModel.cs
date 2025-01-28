using nr.PresentationLayer.Controllers.Api.Models.Customers.Addresses;
using nr.Validation;
using System.ComponentModel.DataAnnotations;

namespace nr.PresentationLayer.Controllers.Api.Models.Customers
{

    [AtLeastOne(nameof(FiscalCode), nameof(VatCode))]
    [AtLeastOne(nameof(Pec), nameof(Sdi))]
    public class CompanyModel
    {
        [Required(AllowEmptyStrings = false), MaxLength(80)]
        public required string CompanyName { get; set; }
        [FiscalCode, StringLength(16, MinimumLength = 16)]
        public string? FiscalCode { get; set; }
        [VatCode, StringLength(11, MinimumLength = 11)]
        public string? VatCode { get; set; }
        [EmailAddress, MaxLength(80)]
        public string? Pec { get; set; }
        [StringLength(5, MinimumLength = 5)]
        public string? Sdi { get; set; }
        public required PostalAddressModel BusinessAddress { get; set; }
        public IEnumerable<AddressModel> AdditionalAddresses { get; set; } = [];
    }
}
