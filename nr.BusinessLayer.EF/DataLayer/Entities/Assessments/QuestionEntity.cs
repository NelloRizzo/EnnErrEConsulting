using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nr.BusinessLayer.EF.DataLayer.Entities.Assessments
{
    [Table("Questions")]
    public class QuestionEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MaxLength(1024)]
        public required string Title { get; set; }
        [Precision(5, 2)]
        public decimal Points { get; set; }
        public virtual ICollection<QuestionAnswerEntity> Answers { get; set; } = [];
    }
}
