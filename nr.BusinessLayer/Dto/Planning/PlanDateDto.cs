using nr.Validation;

namespace nr.BusinessLayer.Dto.Planning
{
    /// <summary>
    /// Una data di erogazione.
    /// </summary>
    [LessThan<TimeOnly>(nameof(StartTime), nameof(EndTime))]
    public class PlanDateDto : BaseDto
    {
        /// <summary>
        /// Data.
        /// </summary>
        public required DateOnly Date { get; set; }
        /// <summary>
        /// Orario di inizio.
        /// </summary>
        public required TimeOnly StartTime { get; set; }
        /// <summary>
        /// Orario di fine.
        /// </summary>
        public required TimeOnly EndTime { get; set; }
    }
}