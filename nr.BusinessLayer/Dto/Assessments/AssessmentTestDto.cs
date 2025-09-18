namespace nr.BusinessLayer.Dto.Assessments
{
    public class AssessmentTestDto : BaseDto
    {
        public IEnumerable<QuestionDto> Questions { get; set; } = [];

    }
}
