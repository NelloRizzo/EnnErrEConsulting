using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nr.BusinessLayer.EF.DataLayer.Entities.Attachments
{
    /// <summary>
    /// Tabella dei collegamenti ai contenuti.
    /// </summary>
    public class LinkEntity
    {
        /// <summary>
        /// Chiave.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Tipo di dato.
        /// </summary>
        [Required, MaxLength(80)]
        public required string MimeType { get; set; }
    }
}