using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nr.BusinessLayer.EF.DataLayer.Entities.Customers
{
    /// <summary>
    /// Tabella delle persone.
    /// </summary>
    [Table("People")]
    public class PersonEntity : CustomerEntity
    {
        /// <summary>
        /// Nome.
        /// </summary>
        [Required(AllowEmptyStrings = false), MaxLength(25)]
        public required string FirstName { get; set; }
        /// <summary>
        /// Cognome.
        /// </summary>
        [Required(AllowEmptyStrings = false), MaxLength(25)]
        public required string LastName { get; set; }
        /// <summary>
        /// Nomignolo.
        /// </summary>
        [MaxLength(25)]
        public string? Nickname { get; set; }
    }
}
