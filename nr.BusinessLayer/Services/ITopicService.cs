using nr.BusinessLayer.Dto.Courses;

namespace nr.BusinessLayer.Services
{
    public interface ITopicService : IService
    {
        Task<TopicDto> AddAsync(TopicDto topicDto);
        Task<TopicDto> UpdateAsync(int topicId, TopicDto topic);
        Task<TopicDto> DeleteAsync(int topicId);
        Task<TopicDto> GetAsync(int topicId);
        Task<IEnumerable<TopicDto>> GetAllAsync();
    }
}
