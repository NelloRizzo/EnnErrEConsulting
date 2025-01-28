using nr.BusinessLayer.EF.DataLayer.Entities.Customers.Addresses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nr.BusinessLayer.EF.DataLayer.Entities.Customers
{
    /// <summary>
    /// Tabella dei clienti.
    /// </summary>
    [Table("Customers")]
    public class CustomerEntity
    {
        /// <summary>
        /// Chiave.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Chiave dell'indirizzo di residenza/sede fiscale.
        /// </summary>
        public int BusinessAddressId { get; set; }
        /// <summary>
        /// Residenza/sede fiscale.
        /// </summary>
        [ForeignKey(nameof(BusinessAddressId))]
        public virtual required PostalAddressEntity BusinessAddress { get; set; }
        /// <summary>
        /// Eventuali altri indirizzi.
        /// </summary>
        public virtual IList<AddressEntity> Addresses { get; set; } = [];
    }
}
