using nr.BusinessLayer.EF.DataLayer.Entities.Operators;
using System.ComponentModel.DataAnnotations.Schema;

namespace nr.BusinessLayer.EF.DataLayer.Entities.Assessments
{
    public class AssessmentsDelivery
    {
        public int AssessmentId { get; set; }
        public int UserId { get; set; }
        public DateOnly DeliveryDate { get; set; }
        [ForeignKey(nameof(AssessmentId))]
        public virtual required AssessmentTestEntity AssessmentTest { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual required UserEntity User { get; set; }

    }
}
