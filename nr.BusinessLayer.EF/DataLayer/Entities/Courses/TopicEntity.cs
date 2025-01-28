using nr.BusinessLayer.EF.DataLayer.Entities.Attachments;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nr.BusinessLayer.EF.DataLayer.Entities.Courses
{
    [Table("Topics")]
    public class TopicEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false), MaxLength(80)]
        public required string Title { get; set; }
        [Required(AllowEmptyStrings = false), MaxLength(4096)]
        public required string Description { get; set; }
        [Required(AllowEmptyStrings = false), MaxLength(1024)]
        public string? Abstract { get; set; }
        public int? StandardDuration { get; set; }
        public virtual IList<TopicEntity> InnerTopics { get; set; } = [];
        public virtual IList<AttachmentEntity> Attachments { get; set; } = [];
        public virtual IList<TopicEntity> Topics { get; set; } = [];
    }
}
