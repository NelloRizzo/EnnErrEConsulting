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
        [Required, MaxLength(1 * 1000000)]
        public required byte[] Content { get; set; }
    }
}
