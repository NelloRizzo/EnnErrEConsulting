using nr.Utils;
using System.ComponentModel.DataAnnotations;

namespace nr.PresentationLayer.Controllers.Api.Models.Attachments
{
    /// <summary>
    /// Un contenuto gestito internamente all'applicazione.
    /// </summary>
    public class ContentLinkModel : LinkModel
    {
        /// <summary>
        /// Discriminante di tipo.
        /// </summary>
        internal static readonly string ModelType = nameof(ContentLinkModel).ToCamelCase().Replace("Model", "");
        /// <summary>
        /// Il contenuto trasformato in bytes.
        /// </summary>
        [Required, MaxLength(1 * 1000000)]
        public required string Content { get; set; }
    }
}
