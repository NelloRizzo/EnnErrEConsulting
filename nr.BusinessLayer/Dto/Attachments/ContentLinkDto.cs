using System.ComponentModel.DataAnnotations;

namespace nr.BusinessLayer.Dto.Attachments
{
    /// <summary>
    /// Un contenuto gestito internamente all'applicazione.
    /// </summary>
    public class ContentLinkDto : LinkDto
    {
        /// <summary>
        /// Il contenuto trasformato in bytes.
        /// </summary>
        [Required, MaxLength(8192)]
        public required byte[] Content { get; set; }
    }
}
