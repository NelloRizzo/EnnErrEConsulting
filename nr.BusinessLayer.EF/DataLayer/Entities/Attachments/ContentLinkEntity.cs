using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nr.BusinessLayer.EF.DataLayer.Entities.Attachments
{
    /// <summary>
    /// Tabella dei contenuti gestiti internamente.
    /// </summary>
    [Table("ContentLinks")]
    public class ContentLinkEntity : LinkEntity
    {
        /// <summary>
        /// Il contenuto trasformato in bytes.
        /// </summary>
        [Required, MaxLength(128 * 1048576)] // 128 Mb max
        public required byte[] Content { get; set; }
    }
}
