using nr.Validation;

namespace nr.BusinessLayer.Dto.Planning
{
    [LessThan<TimeOnly>(nameof(StartTime), nameof(EndTime))]
    public class PlanDateDto : BaseDto
    {
        public required DateOnly Date { get; set; }
        public required TimeOnly StartTime { get; set; }
        public required TimeOnly EndTime { get; set; }
    }
}