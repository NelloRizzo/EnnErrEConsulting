namespace nr.BusinessLayer.Dto.Assessments
{
    public class QuestionAnswer
    {
        public required string Answer { get; set; }
        public bool IsRight { get; set; }
        public decimal Weight { get; set; }
    }
}
