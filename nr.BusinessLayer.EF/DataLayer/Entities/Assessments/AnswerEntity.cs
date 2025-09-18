using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nr.BusinessLayer.EF.DataLayer.Entities.Assessments
{
    [Table("Answers")]
    public class AnswerEntity
    {
        public int Id { get; set; }
        [Required, MaxLength(1024)]
        public required string Text { get; set; }
    }
}
