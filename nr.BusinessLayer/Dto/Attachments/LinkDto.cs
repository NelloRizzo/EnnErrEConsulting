using System.ComponentModel.DataAnnotations;

namespace nr.BusinessLayer.Dto.Attachments
{
    /// <summary>
    /// Classe base per i contenuti.
    /// </summary>
    public abstract class LinkDto : BaseDto
    {
        /// <summary>
        /// Tipo di documento.
        /// </summary>
        [Required, MaxLength(80)]
        public required string MimeType { get; set; }
    }
}