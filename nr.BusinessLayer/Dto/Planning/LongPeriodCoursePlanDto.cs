using nr.Validation;

namespace nr.BusinessLayer.Dto.Planning
{
    [LessThan<DateOnly>(nameof(StartDate), nameof(EndDate))]
    public class LongPeriodCoursePlanDto : BaseDto
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
        /// Data di inizio.
        /// </summary>
        public DateOnly StartDate { get; set; }
        /// <summary>
        /// Data di fine.
        /// </summary>
        public DateOnly EndDate { get; set; }
        /// <summary>
        /// Numero di settimane.
        /// </summary>
        public int Weeks { get; set; }
        /// <summary>
        /// Indica se il corso deve iniziare il lunedì della settimana indicata dalla data di inizio.
        /// </summary>
        public bool? StartsAtMonday { get; set; }
        /// <summary>
        /// Indica se il corso deve terminare il venerdì della settimana indicata dalla data di fine.
        /// </summary>
        public bool? EndsAtFriday { get; set; }
    }
}
