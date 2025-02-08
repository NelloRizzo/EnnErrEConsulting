using nr.BusinessLayer.EF.DataLayer.Entities.Courses;
using nr.BusinessLayer.EF.DataLayer.Entities.Customers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nr.BusinessLayer.EF.DataLayer.Entities.Planning
{
    /// <summary>
    /// Tabella delle pianificazioni.
    /// </summary>
    [Table("CoursePlannings")]
    public class CoursePlanEntity
    {
        /// <summary>
        /// Chiave.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Chiave del corso.
        /// </summary>
        int CourseId { get; set; }
        /// <summary>
        /// Chiave del cliente.
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// Il corso.
        /// </summary>
        [Required, ForeignKey(nameof(CourseId))]
        public virtual required CourseEntity Course { get; set; }
        /// <summary>
        /// Il cliente.
        /// </summary>
        [Required, ForeignKey(nameof(CustomerId))]
        public virtual required CustomerEntity Customer { get; set; }
        /// <summary>
        /// La pianificazione.
        /// </summary>
        public virtual IEnumerable<PlanDateEntity> Dates { get; set; } = [];
    }
}
