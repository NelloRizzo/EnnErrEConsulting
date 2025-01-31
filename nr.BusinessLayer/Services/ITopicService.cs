using nr.BusinessLayer.Dto.Courses;

namespace nr.BusinessLayer.Services
{
    public interface ITopicService : IService
    {
        /// <summary>
        /// Aggiunge un argomento.
        /// </summary>
        /// <param name="topicDto">Dati dell'argomento.</param>
        /// <returns>L'argomento dopo l'inserimento.</returns>
        Task<TopicDto> AddAsync(TopicDto topicDto);
        /// <summary>
        /// Aggiorna un argomento.
        /// </summary>
        /// <param name="topicId">Chiave dell'argomento.</param>
        /// <param name="summary">Descrizione breve (aggiornata solo se diversa da null).</param>
        /// <param name="description">Descrizione lunga (aggiornata solo se diversa da null).</param>
        /// <returns>L'argomento dopo l'aggiornamento.</returns>
        Task<TopicDto> UpdateAsync(int topicId, string? summary, string? description);
        Task<TopicDto> DeleteAsync(int topicId);
        Task<TopicDto> GetAsync(int topicId);
        Task<IEnumerable<TopicDto>> GetAllAsync();
    }
}
