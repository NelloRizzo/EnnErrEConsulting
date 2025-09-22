using System.ComponentModel.DataAnnotations;

namespace nr.PresentationLayer.Controllers.Api.Models.Attachments
{
    /// <summary>
    /// Un allegato con contenuto esterno.
    /// </summary>
    public class NewUrlAttachmentModel
    {
        /// <summary>
        /// Titolo.
        /// </summary>
        [Required, MaxLength(80)]
        public required string Title { get; set; }
        /// <summary>
        /// Descrizione.
        /// </summary>
        [Required, MaxLength(1024)]
        public required string Description { get; set; }
        /// <summary>
        /// Contenuto.
        /// </summary>
        public required UrlLinkModel Content { get; set; }
    }
}
