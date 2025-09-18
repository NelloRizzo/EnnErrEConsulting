namespace nr.BusinessLayer.Dto.Assessments
{
    public class ClosedQuestionDto : QuestionDto
    {
        public IEnumerable<QuestionAnswer> Answers { get; set; } = [];
        public bool IsMultipleChoiceAllowed { get; set; }
    }
}
