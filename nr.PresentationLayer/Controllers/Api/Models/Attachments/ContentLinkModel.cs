using System.ComponentModel.DataAnnotations;

namespace nr.PresentationLayer.Controllers.Api.Models.Attachments
{
    /// <summary>
    /// Un contenuto gestito internamente all'applicazione.
    /// </summary>
    public class ContentLinkModel : LinkModel
    {
        ///// <summary>
        ///// Discriminante di tipo.
        ///// </summary>
        //internal static readonly string ModelType = nameof(ContentLinkModel).ToCamelCase().Replace("Model", "");
        /// <summary>
        /// Il contenuto trasformato in bytes.
        /// </summary>
        [Required, MaxLength(128 * 1048576)] // 128 Mb max
        public required int[] Content { get; set; }
    }
}
