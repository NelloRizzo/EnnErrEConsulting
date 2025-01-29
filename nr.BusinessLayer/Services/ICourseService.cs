using nr.BusinessLayer.Dto.Courses;

namespace nr.BusinessLayer.Services
{
    public interface ICourseService : IService
    {
        Task<CourseDto> AddAsync(CourseDto courseDto);
        Task<IEnumerable<CourseDto>> GetAllAsync();
        Task<CourseDto> LinkTopicAsync(int courseId, int topicId, int order);
        Task<CourseDto> UnlinkTopicAsync(int courseId, int topicId);
        Task<CourseDto> GetAsync(int courseId);
    }
}
