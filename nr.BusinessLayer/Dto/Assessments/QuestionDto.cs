using nr.BusinessLayer.Dto.Courses;

namespace nr.BusinessLayer.Dto.Assessments
{
    public class QuestionDto : BaseDto
    {
        public decimal Points { get; set; }
        public IEnumerable<TopicDto> LinkedTopics { get; set; } = [];
        public IEnumerable<CourseDto> LinkedCourses { get; set; } = [];
    }
}
