using nr.BusinessLayer.Dto.Courses;
using nr.BusinessLayer.Dto.Customers;
using System.ComponentModel.DataAnnotations;

namespace nr.BusinessLayer.Dto.Planning
{
    public class CoursePlanDto : BaseDto
    {
        [Required]
        public required CourseDto Course { get; set; }
        [Required]
        public required CustomerDto Customer { get; set; }
        public IEnumerable<PlanDateDto> Dates { get; set; } = [];
    }
}
