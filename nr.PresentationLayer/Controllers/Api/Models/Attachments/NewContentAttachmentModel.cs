using System.ComponentModel.DataAnnotations;

namespace nr.PresentationLayer.Controllers.Api.Models.Attachments
{
    /// <summary>
    /// Un allegato con contenuto interno.
    /// </summary>
    public class NewContentAttachmentModel
    {
        /// <summary>
        /// Titolo.
        /// </summary>
        [Required, MaxLength(80)]
        public required string Title { get; set; }
        [Required, MaxLength(80)]
        public required string FileName { get; set; }
        /// <summary>
        /// Descrizione.
        /// </summary>
        [Required, MaxLength(1024)]
        public required string Description { get; set; }
        /// <summary>
        /// Contenuto.
        /// </summary>
        public required ContentLinkModel Content { get; set; }
    }
}
