using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nr.BusinessLayer.EF.DataLayer.Entities.Planning
{
    /// <summary>
    /// Tabella delle date pianificate.
    /// </summary>
    [Table("PlanDates")]
    public class PlanDateEntity
    {
        /// <summary>
        /// Chiave.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Data.
        /// </summary>
        public required DateOnly Date { get; set; }
        /// <summary>
        /// Ora di inizio.
        /// </summary>
        public required TimeOnly StartTime { get; set; }
        /// <summary>
        /// Ora di fine.
        /// </summary>
        public required TimeOnly EndTime { get; set; }
    }
}