using System.ComponentModel.DataAnnotations;

namespace nr.PresentationLayer.Controllers.Api.Models.Courses
{
    /// <summary>
    /// Body di request per l'inserimento di un nuovo corso.
    /// </summary>
    public class NewCourseModel
    {
        /// <summary>
        /// Nome del corso.
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
        /// Durata standard in ore.
        /// </summary>
        public int? StandardDurationHours { get; set; }
        /// <summary>
        /// Chiavi dei topics allegati nell'ordine in cui compaiono nel programma del corso.
        /// </summary>
        public IEnumerable<int> Topics { get; set; } = [];
    }
}
