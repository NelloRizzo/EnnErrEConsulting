using System.ComponentModel.DataAnnotations;

namespace nr.PresentationLayer.Controllers.Api.Models.Courses
{
    public class CourseModel
    {
        /// <summary>
        /// Nome del corso.
        /// </summary>
        [Required(AllowEmptyStrings = false), MaxLength(80)]
        public required string Name { get; set; }
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
        /// Elenco degli argomenti.
        /// </summary>
        public IEnumerable<TopicModel> Topics { get; set; } = [];

        /// <summary>
        /// Durata standard in ore.
        /// </summary>
        public int? StandardDurationHours { get; set; }
    }
}
