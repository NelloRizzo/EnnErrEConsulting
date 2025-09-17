namespace nr.BusinessLayer.Dto.Planning
{
    /// <summary>
    /// Pianificazione di un corso.
    /// </summary>
    public class CoursePlanDto : BaseDto
    {
        /// <summary>
        /// Corso.
        /// </summary>
        public required int CourseId { get; set; }
        /// <summary>
        /// Cliente.
        /// </summary>
        public required int CustomerId { get; set; }
        /// <summary>
        /// Date di erogazione.
        /// </summary>
        public IEnumerable<PlanDateDto> Dates { get; set; } = [];
    }
}
