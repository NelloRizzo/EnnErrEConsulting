using System.ComponentModel.DataAnnotations;

namespace nr.BusinessLayer.Dto.Courses
{
    /// <summary>
    /// Un corso di formazione.
    /// </summary>
    public class CourseDto : TaggedDto
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
        [Required(AllowEmptyStrings = false), MaxLength(1024)]
        public string? Abstract { get; set; }
        /// <summary>
        /// Elenco degli argomenti.
        /// </summary>
        public IEnumerable<CourseTopicDto> Topics { get; set; } = [];
        /// <summary>
        /// Durata standard.
        /// </summary>
        public TimeSpan? StandardDuration { get; set; }
        /// <summary>
        /// Durata effettiva calcolando le durate degli argomenti.
        /// </summary>
        public TimeSpan EffectiveDuration => TimeSpan.FromHours(Topics.Sum(t => t.Topic.EffectiveDuration?.Hours ?? 0));
    }
}
