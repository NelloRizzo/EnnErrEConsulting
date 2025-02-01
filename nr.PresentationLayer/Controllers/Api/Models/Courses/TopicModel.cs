using System.ComponentModel.DataAnnotations;

namespace nr.PresentationLayer.Controllers.Api.Models.Courses
{
    public class TopicModel
    {
        /// <summary>
        /// Chiave.
        /// </summary>
        public int Id { get; set; }
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
        /// <summary>
        /// Argomenti collegati.
        /// </summary>
        //public IEnumerable<TopicModel> Topics { get; set; } = [];
        /// <summary>
        /// Documenti collegati.
        /// </summary>
        //public IEnumerable<LinkDto> Links { get; set; } = [];
    }
}
