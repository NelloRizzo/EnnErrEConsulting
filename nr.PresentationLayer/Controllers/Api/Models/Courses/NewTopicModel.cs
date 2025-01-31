using System.ComponentModel.DataAnnotations;

namespace nr.PresentationLayer.Controllers.Api.Models.Courses
{
    public class NewTopicModel
    {
        /// <summary>
        /// Titolo.
        /// </summary>
        [Required(AllowEmptyStrings = false), MaxLength(80)]
        public required string Title { get; set; }
        /// <summary>
        /// Descrizione dettagliata.
        /// </summary>
        [Required(AllowEmptyStrings = false), MaxLength(4096)]
        public required string Description { get; set; }
        /// <summary>
        /// Descrizione breve.
        /// </summary>
        [MaxLength(1024)]
        public string? Abstract { get; set; }
        /// <summary>
        /// Durata standard in ore.
        /// </summary>
        public virtual int? StandardDurationHours { get; set; }
    }
}
