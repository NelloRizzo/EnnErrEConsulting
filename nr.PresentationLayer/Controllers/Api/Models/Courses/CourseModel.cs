namespace nr.PresentationLayer.Controllers.Api.Models.Courses
{
    /// <summary>
    /// Body di response per un corso.
    /// </summary>
    public class CourseModel
    {
        /// <summary>
        /// Nome del corso.
        /// </summary>
        public required string Name { get; set; }
        /// <summary>
        /// Descrizione dettagliata.
        /// </summary>
        public required string Description { get; set; }
        /// <summary>
        /// Descrizione breve.
        /// </summary>
        public string? Abstract { get; set; }

        /// <summary>
        /// Elenco degli argomenti.
        /// </summary>
        public IEnumerable<TopicModel> Topics { get; set; } = [];

        /// <summary>
        /// Durata standard in ore.
        /// </summary>
        public int? StandardDurationHours { get; set; }
    }
}
