using nr.BusinessLayer.EF.DataLayer.Entities.Customers.Addresses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nr.BusinessLayer.EF.DataLayer.Entities.Customers
{
    /// <summary>
    /// Tabella delle aziende.
    /// </summary>
    [Table("Companies")]
    public class CompanyEntity : CustomerEntity
    {
        /// <summary>
        /// Denominazione.
        /// </summary>
        [Required(AllowEmptyStrings = false), MaxLength(80)]
        public required string CompanyName { get; set; }
        /// <summary>
        /// Codice fiscale.
        /// </summary>
        [StringLength(16, MinimumLength = 16)]
        public string? FiscalCode { get; set; }
        /// <summary>
        /// Partita IVA.
        /// </summary>
        [StringLength(11, MinimumLength = 11)]
        public string? VatCode { get; set; }
        /// <summary>
        /// Indirizzo di posta elettronica certificata.
        /// </summary>
        [EmailAddress, MaxLength(80)]
        public virtual required string Pec { get; set; }
        /// <summary>
        /// SDI.
        /// </summary>
        [StringLength(5, MinimumLength = 5)]
        public string? Sdi { get; set; }
    }
}
