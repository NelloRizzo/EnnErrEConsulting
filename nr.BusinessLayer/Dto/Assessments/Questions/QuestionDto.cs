using nr.BusinessLayer.Dto.Courses;

namespace nr.BusinessLayer.Dto.Assessments.Questions
{
    public class QuestionDto : BaseDto
    {
        public required string QuestionText { get; set; }
        public decimal Points { get; set; }
        public IEnumerable<QuestionAnswer> Answers { get; set; } = [];
        public IEnumerable<TopicDto> LinkedTopics { get; set; } = [];
        public IEnumerable<CourseDto> LinkedCourses { get; set; } = [];
    }
}
