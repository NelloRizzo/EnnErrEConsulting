using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nr.BusinessLayer.EF.DataLayer.Entities.Courses
{
    [Table("InnerTopics")]
    public class InnerTopicEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int InnerTopicId { get; set; }
        [ForeignKey(nameof(InnerTopicId))]
        public virtual required TopicEntity InnerTopic { get; set; }
        public int Order { get; set; }
    }
}
