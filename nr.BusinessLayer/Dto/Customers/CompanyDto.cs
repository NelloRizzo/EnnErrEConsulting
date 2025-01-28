using nr.Validation;
using System.ComponentModel.DataAnnotations;

namespace nr.BusinessLayer.Dto.Customers
{
    /// <summary>
    /// Un'azienda.
    /// </summary>
    [AtLeastOne(nameof(FiscalCode), nameof(VatCode))]
    [AtLeastOne(nameof(Pec), nameof(Sdi))]
    public class CompanyDto : CustomerDto
    {
        /// <summary>
        /// Denominazione.
        /// </summary>
        [Required(AllowEmptyStrings = false), MaxLength(80)]
        public required string CompanyName { get; set; }
        /// <summary>
        /// Codice fiscale.
        /// </summary>
        [FiscalCode, StringLength(16, MinimumLength = 16)]
        public string? FiscalCode { get; set; }
        /// <summary>
        /// Partita IVA.
        /// </summary>
        [VatCode, StringLength(11, MinimumLength = 11)]
        public string? VatCode { get; set; }
        /// <summary>
        /// Casella di posta elettronica certificata.
        /// </summary>
        [EmailAddress, MaxLength(80)]
        public string? Pec { get; set; }
        /// <summary>
        /// SDI.
        /// </summary>
        [StringLength(5, MinimumLength = 5)]
        public string? Sdi { get; set; }
        /// <inheritdoc/>
        public override string DisplayName => CompanyName;
    }
}
