using nr.Validation;

namespace nr.PresentationLayer.Controllers.Api.Models.Planning
{
    /// <summary>
    /// Una data di erogazione.
    /// </summary>
    [LessThan<TimeOnly>(nameof(StartTime), nameof(EndTime))]
    public class PlanDateModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Data.
        /// </summary>
        public required DateOnly Date { get; set; }
        /// <summary>
        /// Orario di inizio.
        /// </summary>
        public TimeOnly? StartTime { get; set; }
        /// <summary>
        /// Orario di fine.
        /// </summary>
        public TimeOnly? EndTime { get; set; }
    }
}