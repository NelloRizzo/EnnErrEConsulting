using System.ComponentModel.DataAnnotations;

namespace nr.BusinessLayer.Dto.Customers.Addresses
{
    /// <summary>
    /// Un indirizzo postale.
    /// </summary>
    public class PostalAddressDto : AddressDto
    {
        /// <summary>
        /// La via.
        /// </summary>
        [Required(AllowEmptyStrings = false), MaxLength(125)]
        public required string Street { get; set; }
        /// <summary>
        /// Il numero civico.
        /// </summary>
        [Required(AllowEmptyStrings = true), MaxLength(10)]
        public required string CivicNumber { get; set; }
        /// <summary>
        /// La città.
        /// </summary>
        [Required(AllowEmptyStrings = false), MaxLength(80)]
        public required string City { get; set; }
        /// <summary>
        /// La provincia.
        /// </summary>
        [Required(AllowEmptyStrings = false), StringLength(2, MinimumLength = 2)]
        public required string Region { get; set; }
        /// <summary>
        /// Il codice di avviamento postale.
        /// </summary>
        [Required(AllowEmptyStrings = false), MaxLength(10)]
        public required string PostalCode { get; set; }
        /// <summary>
        /// La nazione.
        /// </summary>
        [StringLength(3, MinimumLength = 3)]
        public string? Country { get; set; } = "ITA";
    }
}
