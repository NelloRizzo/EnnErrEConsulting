using nr.BusinessLayer.Dto.Courses;

namespace nr.BusinessLayer.Services
{
    public interface ICourseService : IService
    {
        /// <summary>
        /// Aggiunge un corso.
        /// </summary>
        /// <param name="courseDto">Dati del corso da aggiungere.</param>
        /// <param name="topicIds">Elenco degli argomenti collegati, nell'ordine in cui appaiono all'interno del corso.</param>
        /// <returns>Il corso dopo l'inserimento.</returns>
        Task<CourseDto> AddAsync(CourseDto courseDto, IEnumerable<int> topicIds);
        /// <summary>
        /// Recupera tutti i corsi.
        /// </summary>
        Task<IEnumerable<CourseDto>> GetAllAsync();
        /// <summary>
        /// Aggiunge degli argomenti ad un corso.
        /// </summary>
        /// <param name="courseId">La chiave del corso.</param>
        /// <param name="order">L'indice da cui inserire gli argomenti nel programma del corso.</param>
        /// <param name="topicIds">Le chiavi degli argomenti da aggiungere.</param>
        /// <returns>Il corso dopo l'inserimento.</returns>
        Task<CourseDto> LinkTopicAsync(int courseId, int order, IEnumerable<int> topicIds);
        /// <summary>
        /// Elimina un argomento dal corso.
        /// </summary>
        /// <param name="courseId">La chiave del corso.</param>
        /// <param name="topicIds">La chiave dell'argomento.</param>
        /// <returns>Il corso dopo l'eliminazione.</returns>
        Task<CourseDto> UnlinkTopicAsync(int courseId, IEnumerable<int> topicIds);
        /// <summary>
        /// Recupera i dati di un corso.
        /// </summary>
        /// <param name="courseId">La chiave del corso.</param>
        /// <returns>Il corso desiderato.</returns>
        Task<CourseDto> GetAsync(int courseId);
    }
}
