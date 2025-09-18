using nr.BusinessLayer.Dto.Operators;

namespace nr.BusinessLayer.Dto.Assessments
{
    public class UserAssessmentDto : BaseDto
    {
        public required UserDto User { get; set; }
        public required AssessmentTestDto AssessmentTest { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IEnumerable<decimal> Points { get; set; } = [];
        public decimal TotalPoints => Points.Sum();
    }
}
