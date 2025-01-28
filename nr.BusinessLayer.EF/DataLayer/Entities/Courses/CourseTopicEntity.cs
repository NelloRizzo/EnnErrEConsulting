using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nr.BusinessLayer.EF.DataLayer.Entities.Courses
{
    /// <summary>
    /// Tabella dei collegamenti tra corsi e argomenti.
    /// </summary>
    [Table("CoursesTopics")]
    [Index(nameof(CourseId), nameof(TopicId), IsUnique = true, Name = "IDX_TOPIC_COURSE_UNIQUE")]
    public class CourseTopicEntity
    {
        /// <summary>
        /// Chiave.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Ordine dell'argomento nell'elenco degli argomenti.
        /// </summary>
        [Range(0, 100)]
        public int Order { get; set; }
        /// <summary>
        /// Chiave dell'argomento.
        /// </summary>
        public int TopicId { get; set; }
        /// <summary>
        /// Chiave del corso.
        /// </summary>
        public int CourseId { get; set; }
        /// <summary>
        /// Argomento.
        /// </summary>
        [Required, ForeignKey(nameof(TopicId))]
        public virtual required TopicEntity Topic { get; set; }
        /// <summary>
        /// Corso.
        /// </summary>
        [Required, ForeignKey(nameof(CourseId))]
        public virtual required CourseEntity Course { get; set; }
    }
}
