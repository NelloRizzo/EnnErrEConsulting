using nr.BusinessLayer.EF.DataLayer.Entities.Courses;
using nr.BusinessLayer.EF.DataLayer.Entities.Customers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nr.BusinessLayer.EF.DataLayer.Entities.Planning
{
    [Table("CoursePlannings")]
    public class CoursePlanEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        int CourseId { get; set; }
        public int CustomerId { get; set; }
        [Required, ForeignKey(nameof(CourseId))]
        public required CourseEntity Course { get; set; }
        [Required, ForeignKey(nameof(CustomerId))]
        public virtual required CustomerEntity Customer { get; set; }
        public virtual IEnumerable<PlanDateEntity> Dates { get; set; } = [];
    }
}
