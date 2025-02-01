namespace nr.PresentationLayer.Controllers.Api.Models.Courses
{
    /// <summary>
    /// Body di request per scollegare degli argomenti da un corso.
    /// </summary>
    public class UnlinkTopicModel
    {
        /// <summary>
        /// Elenco delle chiavi degli argomenti da scollegare.
        /// </summary>
        public IEnumerable<int> TopicIds { get; set; } = [];
    }
}
