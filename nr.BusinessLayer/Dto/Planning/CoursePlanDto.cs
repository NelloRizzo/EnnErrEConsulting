using nr.BusinessLayer.Dto.Courses;
using nr.BusinessLayer.Dto.Customers;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        public required CourseDto Course { get; set; }
        /// <summary>
        /// Cliente.
        /// </summary>
        [Required]
        public required CustomerDto Customer { get; set; }
        /// <summary>
        /// Date di erogazione.
        /// </summary>
        public IEnumerable<PlanDateDto> Dates { get; set; } = [];
    }
}
