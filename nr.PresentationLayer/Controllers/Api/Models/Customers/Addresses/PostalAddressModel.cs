using nr.Utils;
using System.ComponentModel.DataAnnotations;

namespace nr.PresentationLayer.Controllers.Api.Models.Customers.Addresses
{
    /// <summary>
    /// Un indirizzo postale.
    /// </summary>
    public class PostalAddressModel : AddressModel
    {
        /// <summary>
        /// Discriminante di tipo.
        /// </summary>
        internal static readonly string ModelType = nameof(PostalAddressModel).ToCamelCase().Replace("Model", "");
        /// <summary>
        /// La via.
        /// </summary>
        [Required(AllowEmptyStrings = false), MaxLength(125)]
        public required string Street { get; set; }
        /// <summary>
        /// Numero civico.
        /// </summary>
        [Required(AllowEmptyStrings = true), MaxLength(10)]
        public required string CivicNumber { get; set; }
        /// <summary>
        /// Città.
        /// </summary>
        [Required(AllowEmptyStrings = false), MaxLength(80)]
        public required string City { get; set; }
        /// <summary>
        /// Provincia/Regione.
        /// </summary>
        [Required(AllowEmptyStrings = false), StringLength(2, MinimumLength = 2)]
        public required string Region { get; set; }
        /// <summary>
        /// Codice di avviamento postale.
        /// </summary>
        [Required(AllowEmptyStrings = false), MaxLength(10)]
        public required string PostalCode { get; set; }
        /// <summary>
        /// Nazione.
        /// </summary>
        [StringLength(3, MinimumLength = 3)]
        public string? Country { get; set; } = "ITA";
    }
}
