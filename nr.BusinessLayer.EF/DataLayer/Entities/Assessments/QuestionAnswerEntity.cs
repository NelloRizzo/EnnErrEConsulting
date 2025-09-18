using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace nr.BusinessLayer.EF.DataLayer.Entities.Assessments
{
    public class QuestionAnswerEntity
    {
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        [ForeignKey(nameof(AnswerId))]
        public virtual required AnswerEntity Answer { get; set; }
        [ForeignKey(nameof(QuestionId))]
        public virtual required QuestionEntity QuestionEntity { get; set; }
        [Precision(5, 2)]
        public decimal Weight { get; set; }
        public bool IsRightAnswer { get; set; }

    }
}
