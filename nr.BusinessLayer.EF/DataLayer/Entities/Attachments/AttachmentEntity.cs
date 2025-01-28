using nr.BusinessLayer.EF.DataLayer.Entities.Courses;
using nr.BusinessLayer.EF.DataLayer.Entities.Tags;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nr.BusinessLayer.EF.DataLayer.Entities.Attachments
{
    /// <summary>
    /// Tabella degli allegati.
    /// </summary>
    [Table("Attachments")]
    public class AttachmentEntity
    {
        /// <summary>
        /// Chiave.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Titolo.
        /// </summary>
        [Required, MaxLength(80)]
        public required string Title { get; set; }
        /// <summary>
        /// Descrizione.
        /// </summary>
        [Required, MaxLength(1024)]
        public required string Description { get; set; }
        /// <summary>
        /// Chiave per il recupero del contenuto dell'allegato.
        /// </summary>
        public int LinkId { get; set; }
        /// <summary>
        /// Il contenuto dell'allegato.
        /// </summary>
        [ForeignKey(nameof(LinkId))]
        public virtual required LinkEntity Link { get; set; }
        /// <summary>
        /// Elenco degli argomenti ai quali è collegato.
        /// </summary>
        public virtual IList<TopicEntity> Topics { get; set; } = [];
        /// <summary>
        /// Elenco dei corsi ai quali è collegato.
        /// </summary>
        public virtual IList<CourseEntity> Courses { get; set; } = [];
        /// <summary>
        /// Elenco dei tags ai quali è collegato.
        /// </summary>
        public virtual IList<TagEntity> Tags { get; set; } = [];
    }
}
