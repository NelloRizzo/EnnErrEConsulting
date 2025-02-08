namespace nr.PresentationLayer.Controllers.Api.Models.Planning
{
    /// <summary>
    /// Pianificazione di un corso.
    /// </summary>
    public class CoursePlanModel
    {
        /// <summary>
        /// Chiave.
        /// </summary>
        public int Id { get; set; }
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
        public IEnumerable<PlanDateModel> Dates { get; set; } = [];
    }
}
