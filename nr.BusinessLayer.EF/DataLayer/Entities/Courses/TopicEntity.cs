using nr.BusinessLayer.EF.DataLayer.Entities.Attachments;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nr.BusinessLayer.EF.DataLayer.Entities.Courses
{
    /// <summary>
    /// Tabella degli argomenti.
    /// </summary>
    [Table("Topics")]
    public class TopicEntity
    {
        /// <summary>
        /// Chiave.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Titolo.
        /// </summary>
        [Required(AllowEmptyStrings = false), MaxLength(80)]
        public required string Title { get; set; }
        /// <summary>
        /// Descrizione dettagliata.
        /// </summary>
        [Required(AllowEmptyStrings = false), MaxLength(4096)]
        public required string Description { get; set; }
        /// <summary>
        /// Descrizione breve.
        /// </summary>
        [Required(AllowEmptyStrings = false), MaxLength(1024)]
        public string? Abstract { get; set; }
        /// <summary>
        /// Durata standard.
        /// </summary>
        public int? StandardDuration { get; set; }
        /// <summary>
        /// Argomenti interni.
        /// </summary>
        public virtual IList<TopicEntity> InnerTopics { get; set; } = [];
        /// <summary>
        /// Allegati.
        /// </summary>
        public virtual IList<AttachmentEntity> Attachments { get; set; } = [];
        /// <summary>
        /// Argomenti.
        /// </summary>
        // TODO: Probabilmente da sostituirsi con tags.
        public virtual IList<TopicEntity> Topics { get; set; } = [];
    }
}
