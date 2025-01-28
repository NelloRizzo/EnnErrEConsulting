using System.ComponentModel.DataAnnotations;

namespace nr.BusinessLayer.Dto.Courses
{
    public class CourseTopicDto : BaseDto
    {
        [Range(0, 100)]
        public int Order { get; set; }
        [Required]
        public required TopicDto Topic { get; set; }
        [Required]
        public required CourseDto Course { get; set; }
        public override int GetHashCode() => HashCode.Combine(Topic, Course);
    }
}
