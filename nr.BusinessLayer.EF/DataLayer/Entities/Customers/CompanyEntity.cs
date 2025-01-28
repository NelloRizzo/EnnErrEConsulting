using nr.BusinessLayer.EF.DataLayer.Entities.Customers.Addresses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nr.BusinessLayer.EF.DataLayer.Entities.Customers
{
    [Table("Companies")]
    public class CompanyEntity : CustomerEntity
    {
        [Required(AllowEmptyStrings = false), MaxLength(80)]
        public required string CompanyName { get; set; }
        [StringLength(16, MinimumLength = 16)]
        public string? FiscalCode { get; set; }
        [StringLength(11, MinimumLength = 11)]
        public string? VatCode { get; set; }
        [EmailAddress, MaxLength(80)]
        public virtual EmailAddressEntity? Pec { get; set; }
        [StringLength(5, MinimumLength = 5)]
        public string? Sdi { get; set; }
    }
}
