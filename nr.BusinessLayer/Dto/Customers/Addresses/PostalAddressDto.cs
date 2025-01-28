using System.ComponentModel.DataAnnotations;

namespace nr.BusinessLayer.Dto.Customers.Addresses
{
    public class PostalAddressDto : AddressDto
    {
        [Required(AllowEmptyStrings = false), MaxLength(125)]
        public required string Address { get; set; }
        [Required(AllowEmptyStrings = true), MaxLength(10)]
        public required string CivicNumber { get; set; }
        [Required(AllowEmptyStrings = false), MaxLength(80)]
        public required string City { get; set; }
        [Required(AllowEmptyStrings = false), StringLength(2, MinimumLength = 2)]
        public required string Region { get; set; }
        [Required(AllowEmptyStrings = false), MaxLength(10)]
        public required string PostalCode { get; set; }
        [StringLength(3, MinimumLength = 3)]
        public string? Country { get; set; } = "ITA";
    }
}
