using Microsoft.EntityFrameworkCore;
using nr.BusinessLayer.EF.DataLayer.Entities.Attachments;
using nr.BusinessLayer.EF.DataLayer.Entities.Courses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nr.BusinessLayer.EF.DataLayer.Entities.Tags
{
    [Table("Tags")]
    [Index(nameof(TagName), IsUnique = true, Name = "IDX_TagName_Unique")]
    public class TagEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MaxLength(25)]
        public required string TagName { get; set; }
        public virtual IList<AttachmentEntity> Attachments { get; set; } = [];
        public virtual IList<CourseEntity> Courses { get; set; } = [];
        public virtual IList<TopicEntity> Topics { get; set; } = [];
    }
}