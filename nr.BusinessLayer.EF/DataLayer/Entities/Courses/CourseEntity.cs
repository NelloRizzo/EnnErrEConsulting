using nr.BusinessLayer.EF.DataLayer.Entities.Attachments;
using nr.BusinessLayer.EF.DataLayer.Entities.Tags;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nr.BusinessLayer.EF.DataLayer.Entities.Courses
{
    [Table("Courses")]
    public class CourseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false), MaxLength(80)]
        public required string Name { get; set; }
        [Required(AllowEmptyStrings = false), MaxLength(4096)]
        public required string Description { get; set; }
        [Required(AllowEmptyStrings = false), MaxLength(1024)]
        public string? Abstract { get; set; }
        public int? StandardDuration { get; set; }
        public virtual IList<CourseTopicEntity> Topics { get; set; } = [];
        public virtual IList<TagEntity> Tags { get; set; } = [];
        public virtual IList<AttachmentEntity> Attachments { get; set; } = [];
    }
}
