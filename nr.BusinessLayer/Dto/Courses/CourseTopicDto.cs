using System.ComponentModel.DataAnnotations;

namespace nr.BusinessLayer.Dto.Courses
{
    /// <summary>
    /// Un argomento di un corso.
    /// </summary>
    public class CourseTopicDto : BaseDto
    {
        /// <summary>
        /// Ordine nell'elenco degli argomenti.
        /// </summary>
        [Range(0, 100)]
        public int Order { get; set; }
        /// <summary>
        /// Argomento.
        /// </summary>
        [Required]
        public required TopicDto Topic { get; set; }
        /// <summary>
        /// Corso.
        /// </summary>
        [Required]
        public required CourseDto Course { get; set; }
        /// <inheritdoc/>
        public override int GetHashCode() => HashCode.Combine(Topic, Course);
    }
}
