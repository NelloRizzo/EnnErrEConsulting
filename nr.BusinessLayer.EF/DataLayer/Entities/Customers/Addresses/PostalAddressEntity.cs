using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nr.BusinessLayer.EF.DataLayer.Entities.Customers.Addresses
{
    /// <summary>
    /// Tabella degli indirizzi postali.
    /// </summary>
    [Table("PostalAddresses")]
    public class PostalAddressEntity : AddressEntity
    {
        /// <summary>
        /// Via.
        /// </summary>
        // TODO: Cambiare il nome in Street
        [Required(AllowEmptyStrings = false), MaxLength(125)]
        public required string Street { get; set; }
        /// <summary>
        /// Numero civico.
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
        /// Lo stato.
        /// </summary>
        [StringLength(3, MinimumLength = 3)]
        public string? Country { get; set; } = "ITA";
    }
}
