using nr.Utils;
using System.ComponentModel.DataAnnotations;

namespace nr.PresentationLayer.Controllers.Api.Models.Attachments
{
    /// <summary>
    /// Link ad un contenuto esterno.
    /// </summary>
    public class UrlLinkModel : LinkModel
    {
        /// <summary>
        /// Discriminante di tipo.
        /// </summary>
        internal static readonly string ModelType = nameof(UrlLinkModel).ToCamelCase().Replace("Model", "");
        [Required, MaxLength(512)]
        public required string Url { get; set; }
    }
}
