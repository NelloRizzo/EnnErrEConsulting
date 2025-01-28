using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nr.BusinessLayer.EF.DataLayer.Entities.Courses
{
    [Table("CoursesTopics")]
    [Index(nameof(CourseId), nameof(TopicId), IsUnique = true, Name = "IDX_TOPIC_COURSE_UNIQUE")]
    public class CourseTopicEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Range(0, 100)]
        public int Order { get; set; }
        public int TopicId { get; set; }
        public int CourseId { get; set; }
        [Required, ForeignKey(nameof(TopicId))]
        public virtual required TopicEntity Topic { get; set; }
        [Required, ForeignKey(nameof(CourseId))]
        public virtual required CourseEntity Course { get; set; }
    }
}
