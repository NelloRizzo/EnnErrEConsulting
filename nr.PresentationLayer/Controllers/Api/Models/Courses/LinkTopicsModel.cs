namespace nr.PresentationLayer.Controllers.Api.Models.Courses
{
    /// <summary>
    /// Body di request per collegare gli argomenti ai corsi.
    /// </summary>
    public class LinkTopicsModel
    {
        /// <summary>
        /// Elenco delle chiavi degli argomenti da collegare.
        /// </summary>
        public IEnumerable<int> TopicIds { get; set; } = [];
        /// <summary>
        /// Posizione da cui incominciare ad inserire.
        /// </summary>
        public int Order { get; set; }
    }
}
