using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nr.BusinessLayer.EF.DataLayer.Entities.Customers.Addresses
{
    /// <summary>
    /// Tabella degli indirizzi.
    /// </summary>
    [Table("Addresses")]
    public abstract class AddressEntity
    {
        /// <summary>
        /// Chiave.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Indica se si tratta di un indirizzo di lavoro.
        /// </summary>
        public bool IsBusiness { get; set; }
    }
}