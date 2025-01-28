using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nr.BusinessLayer.EF.DataLayer.Entities.Customers.Addresses
{
    /// <summary>
    /// Tabella degli indirizzi email.
    /// </summary>
    [Table("Emails")]
    public class EmailAddressEntity : AddressEntity
    {
        /// <summary>
        /// L'indirizzo email.
        /// </summary>
        [Required, EmailAddress, MaxLength(80)]
        public required string Email { get; set; }
    }
}
