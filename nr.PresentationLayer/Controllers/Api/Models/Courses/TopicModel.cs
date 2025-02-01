namespace nr.PresentationLayer.Controllers.Api.Models.Courses
{
    /// <summary>
    /// Body di response per la restituzione di un argomento.
    /// </summary>
    public class TopicModel
    {
        /// <summary>
        /// Chiave.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Titolo.
        /// </summary>
        public required string Title { get; set; }
        /// <summary>
        /// Descrizione dettagliata.
        /// </summary>
        public required string Description { get; set; }
        /// <summary>
        /// Descrizione breve.
        /// </summary>
        public string? Abstract { get; set; }
        /// <summary>
        /// Durata standard in ore.
        /// </summary>
        public virtual int? StandardDurationHours { get; set; }
        /// <summary>
        /// Argomenti collegati.
        /// </summary>
        //public IEnumerable<TopicModel> Topics { get; set; } = [];
        /// <summary>
        /// Documenti collegati.
        /// </summary>
        //public IEnumerable<LinkDto> Links { get; set; } = [];
    }
}
