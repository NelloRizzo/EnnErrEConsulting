using nr.Validation;
using System.ComponentModel.DataAnnotations;

namespace nr.BusinessLayer.Dto.Planning
{
    public class WeeklyCoursePlanDto : BaseDto
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
        /// Numero di settimane.
        /// </summary>
        [Range(1, 72)]
        public int Weeks { get; set; }
        /// <summary>
        /// Indica se il corso deve iniziare il lunedì a prescindere dalla data di inizio.
        /// </summary>
        public bool? StartsAtMonday { get; set; }
        /// <summary>
        /// Indica se il corso deve terminare il venerdì oppure deve continuare per 5 giorni a partire dalla data di inizio.
        /// </summary>
        public bool? EndsAtFriday { get; set; }
    }
}
