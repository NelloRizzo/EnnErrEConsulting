using nr.BusinessLayer.EF.DataLayer.Entities.Attachments;
using nr.BusinessLayer.EF.DataLayer.Entities.Tags;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nr.BusinessLayer.EF.DataLayer.Entities.Courses
{
    /// <summary>
    /// Tabella dei corsi.
    /// </summary>
    [Table("Courses")]
    public class CourseEntity
    {
        /// <summary>
        /// Chiave.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Nome.
        /// </summary>
        [Required(AllowEmptyStrings = false), MaxLength(80)]
        public required string Name { get; set; }
        /// <summary>
        /// Descrizione dettagliata.
        /// </summary>
        [Required(AllowEmptyStrings = false), MaxLength(4096)]
        public required string Description { get; set; }
        /// <summary>
        /// Descrizione breve.
        /// </summary>
        [MaxLength(1024)]
        public string? Abstract { get; set; }
        /// <summary>
        /// Durata standard.
        /// </summary>
        public int? StandardDuration { get; set; }
        /// <summary>
        /// Elenco degli argomenti collegati.
        /// </summary>
        public virtual IList<CourseTopicEntity> Topics { get; set; } = [];
        /// <summary>
        /// Elenco dei tags collegati.
        /// </summary>
        public virtual IList<TagEntity> Tags { get; set; } = [];
        /// <summary>
        /// Elenco degli allegati collegati.
        /// </summary>
        public virtual IList<AttachmentEntity> Attachments { get; set; } = [];
    }
}
