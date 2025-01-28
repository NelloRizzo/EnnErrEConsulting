using Microsoft.EntityFrameworkCore;
using nr.BusinessLayer.EF.DataLayer.Entities.Attachments;
using nr.BusinessLayer.EF.DataLayer.Entities.Courses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nr.BusinessLayer.EF.DataLayer.Entities.Tags
{
    /// <summary>
    /// Tabella dei tags.
    /// </summary>
    [Table("Tags")]
    [Index(nameof(TagName), IsUnique = true, Name = "IDX_TagName_Unique")]
    public class TagEntity
    {
        /// <summary>
        /// Chiave.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Tag.
        /// </summary>
        [Required, MaxLength(25)]
        public required string TagName { get; set; }
        /// <summary>
        /// Allegati collegati.
        /// </summary>
        public virtual IList<AttachmentEntity> Attachments { get; set; } = [];
        /// <summary>
        /// Corsi collegati.
        /// </summary>
        public virtual IList<CourseEntity> Courses { get; set; } = [];
        /// <summary>
        /// Argomenti collegati.
        /// </summary>
        public virtual IList<TopicEntity> Topics { get; set; } = [];
    }
}