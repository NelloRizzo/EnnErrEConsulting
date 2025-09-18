using nr.BusinessLayer.Dto.Assessments.Questions;
using nr.BusinessLayer.Dto.Courses;

namespace nr.BusinessLayer.Dto.Assessments
{
    public class AssessmentTestDto : BaseDto
    {
        public IEnumerable<QuestionDto> Questions { get; set; } = [];
        public required string Title { get; set; }
        public IEnumerable<TopicDto> LinkedTopics { get; set; } = [];
        public IEnumerable<CourseDto> LinkedCourses { get; set; } = [];
        public decimal MinimumTarget { get; set; }
    }
}
