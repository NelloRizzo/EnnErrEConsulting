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
                return mapper.Map<CourseDto>(course);
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
                return mapper.Map<IEnumerable<CourseDto>>(await context.Courses.ToListAsync());
            }
            catch (Exception ex) {
                logger.LogError(ex, "Unattended exception getting all courses");
                throw new ServiceException(innerException: ex);
            }
        }

        /// <inheritdoc/>
        /// <exception cref="ServiceException"></exception>
        public async Task<CourseDto> GetAsync(int courseId) {
            try {
                return mapper.Map<CourseDto>(await context.Courses.FindAsync(courseId));
            }
            catch (Exception ex) {
                logger.LogError(ex, "Unattended exception getting course {}", courseId);
                throw new ServiceException(innerException: ex);
            }
        }

        /// <inheritdoc/>
        /// <exception cref="EntityNotFoundException"></exception>
        /// <exception cref="ServiceException"></exception>
        public async Task<CourseDto> LinkTopicAsync(int courseId, int order, params int[] topicIds) {
            try {
                var course = await context.Courses.FindAsync(courseId) ?? throw new EntityNotFoundException { SearchedKey = courseId, SearchedType = typeof(CourseDto) };
                var trans = await context.Database.BeginTransactionAsync();
                foreach (var id in topicIds) {
                    var topic = await context.Topics.FindAsync(topicIds) ?? throw new EntityNotFoundException { SearchedType = typeof(TopicDto), SearchedKey = id };
                    course.Topics.Add(new CourseTopicEntity { Course = course, Topic = topic, CourseId = courseId, TopicId = id, Order = order });
                }
                await context.SaveChangesAsync();
                await trans.CommitAsync();
                return mapper.Map<CourseDto>(course);
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
        public async Task<CourseDto> UnlinkTopicAsync(int courseId, int topicId) {
            try {
                var course = await context.Courses.FindAsync(courseId) ?? throw new EntityNotFoundException { SearchedKey = courseId, SearchedType = typeof(CourseDto) };
                var topic = course.Topics.FirstOrDefault(t => t.TopicId == topicId);
                if (topic != null) {
                    course.Topics.Remove(topic);
                    await context.SaveChangesAsync();
                }
                return mapper.Map<CourseDto>(course);
            }
            catch (ServiceException) {
                throw;
            }
            catch (Exception ex) {
                logger.LogError(ex, "Unattended exception unlinking topic {} from course {}", topicId, courseId);
                throw new ServiceException(innerException: ex);
            }
        }
    }
}
