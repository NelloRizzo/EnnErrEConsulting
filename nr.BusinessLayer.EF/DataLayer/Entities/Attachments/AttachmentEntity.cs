using nr.BusinessLayer.EF.DataLayer.Entities.Courses;
using nr.BusinessLayer.EF.DataLayer.Entities.Tags;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nr.BusinessLayer.EF.DataLayer.Entities.Attachments
{
    [Table("Attachments")]
    public class AttachmentEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MaxLength(80)]
        public required string Title { get; set; }
        [Required, MaxLength(1024)]
        public required string Description { get; set; }
        public int LinkId { get; set; }
        public virtual IList<TopicEntity> Topics { get; set; } = [];
        public virtual IList<CourseEntity> Courses { get; set; } = [];
        public virtual IList<TagEntity> Tags { get; set; } = [];
    }
}
