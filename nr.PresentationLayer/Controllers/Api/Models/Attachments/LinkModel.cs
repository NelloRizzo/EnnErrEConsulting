using nr.PresentationLayer.Controllers.Api.JsonConverters;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace nr.PresentationLayer.Controllers.Api.Models.Attachments
{
    /// <summary>
    /// Classe base per i contenuti.
    /// </summary>
    [JsonConverter(typeof(LinkModelConverter))]
    public abstract class LinkModel
    {
        /// <summary>
        /// Chiave.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Tipo di documento.
        /// </summary>
        [Required, MaxLength(80)]
        public virtual required string MimeType { get; set; }
        /// <summary>
        /// Discriminante di tipo per serializzazione e deserializzazione JSON.
        /// </summary>
        public string? Type { get; set; }
    }
}