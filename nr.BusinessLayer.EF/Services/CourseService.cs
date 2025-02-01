using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using nr.BusinessLayer.Dto.Courses;
using nr.BusinessLayer.EF.DataLayer;
using nr.BusinessLayer.EF.DataLayer.Entities.Courses;
using nr.BusinessLayer.Services;
using nr.BusinessLayer.Services.Exceptions;
using nr.Validation;

namespace nr.BusinessLayer.EF.Services
{
    public class CourseService(ILogger<Service> logger, ApplicationDBContext context) : Service(), ICourseService
    {
        private CourseDto Map(CourseEntity course) {
            var dto = mapper.Map<CourseDto>(course);
            dto.Topics = course.Topics.Select(t => t.Topic).Select(mapper.Map<TopicDto>).ToList();
            return dto;
        }
        /// <inheritdoc/>
        /// <exception cref="InvalidDtoException"></exception>
        /// <exception cref="ServiceException"></exception>
        public async Task<CourseDto> AddAsync(CourseDto courseDto, IEnumerable<int> topicIds) {
            try {
                if (!courseDto.IsValid()) throw new InvalidDtoException { InvalidDto = courseDto };
                var trans = await context.Database.BeginTransactionAsync();
                var course = mapper.Map<CourseEntity>(courseDto);
                context.Courses.Add(course);
                await context.SaveChangesAsync();
                if (topicIds.Any()) {
                    int order = 10;
                    foreach (var topicId in topicIds) {
                        var topic = await context.Topics.FindAsync(topicId) ?? throw new EntityNotFoundException { SearchedKey = topicId, SearchedType = typeof(TopicDto) };
                        course.Topics.Add(new CourseTopicEntity { Course = course, Topic = topic, CourseId = course.Id, TopicId = topicId, Order = order });
                        order += 10;
                    }
                    await context.SaveChangesAsync();
                }
                await trans.CommitAsync();
                return Map(course);
            }
            catch (ServiceException) {
                throw;
            }
            catch (Exception ex) {
                logger.LogError(ex, "Unattended exception adding course");
                throw new ServiceException(innerException: ex);
            }
        }

        /// <inheritdoc/>
        /// <exception cref="ServiceException"></exception>
        public async Task<IEnumerable<CourseDto>> GetAllAsync() {
            try {
                return (await context.Courses.ToListAsync()).Select(Map);
            }
            catch (Exception ex) {
                logger.LogError(ex, "Unattended exception getting all courses");
                throw new ServiceException(innerException: ex);
            }
        }

        /// <inheritdoc/>
        /// <exception cref="ServiceException"></exception>
        public async Task<CourseDto?> GetAsync(int courseId) {
            try {
                var course = await context.Courses.FindAsync(courseId);
                if (course == null) return null;
                return Map(course);
            }
            catch (Exception ex) {
                logger.LogError(ex, "Unattended exception getting course {}", courseId);
                throw new ServiceException(innerException: ex);
            }
        }

        /// <inheritdoc/>
        /// <exception cref="EntityNotFoundException"></exception>
        /// <exception cref="ServiceException"></exception>
        public async Task<CourseDto> LinkTopicAsync(int courseId, int order, IEnumerable<int> topicIds) {
            try {
                var course = await context.Courses.SingleOrDefaultAsync(c => c.Id == courseId) ?? throw new EntityNotFoundException { SearchedKey = courseId, SearchedType = typeof(CourseDto) };
                var trans = await context.Database.BeginTransactionAsync();
                foreach (var id in topicIds) {
                    var topic = await context.Topics.FindAsync(id) ?? throw new EntityNotFoundException { SearchedType = typeof(TopicDto), SearchedKey = id };
                    course.Topics.Add(new CourseTopicEntity { Course = course, Topic = topic, CourseId = courseId, TopicId = topic.Id, Order = order });
                }
                await context.SaveChangesAsync();
                await trans.CommitAsync();
                return Map(course);
            }
            catch (ServiceException) {
                throw;
            }
            catch (Exception ex) {
                logger.LogError(ex, "Unattended exception linking topic {} to course {}", topicIds, courseId);
                throw new ServiceException(innerException: ex);
            }
        }

        /// <inheritdoc/>
        /// <exception cref="EntityNotFoundException"></exception>
        /// <exception cref="ServiceException"></exception>
        public async Task<CourseDto> UnlinkTopicAsync(int courseId, IEnumerable<int> topicIds) {
            try {
                var course = await context.Courses.FindAsync(courseId) ?? throw new EntityNotFoundException { SearchedKey = courseId, SearchedType = typeof(CourseDto) };
                foreach (var id in topicIds) {
                    var topic = course.Topics.FirstOrDefault(t => t.TopicId == id);
                    if (topic != null) {
                        course.Topics.Remove(topic);
                    }
                }
                await context.SaveChangesAsync();
                return Map(course);
            }
            catch (ServiceException) {
                throw;
            }
            catch (Exception ex) {
                logger.LogError(ex, "Unattended exception unlinking topics {} from course {}", topicIds, courseId);
                throw new ServiceException(innerException: ex);
            }
        }
    }
}
