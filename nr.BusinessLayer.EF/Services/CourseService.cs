using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using nr.BusinessLayer.Dto.Courses;
using nr.BusinessLayer.EF.DataLayer;
using nr.BusinessLayer.EF.DataLayer.Entities.Courses;
using nr.BusinessLayer.Services;
using nr.BusinessLayer.Services.Exceptions;
using nr.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nr.BusinessLayer.EF.Services
{
    public class CourseService(ILogger<Service> logger, ApplicationDBContext context) : Service(), ICourseService
    {
        /// <inheritdoc/>
        /// <exception cref="InvalidDtoException"></exception>
        /// <exception cref="ServiceException"></exception>
        public async Task<CourseDto> AddAsync(CourseDto courseDto) {
            try {
                if (!courseDto.IsValid()) throw new InvalidDtoException { InvalidDto = courseDto };
                var course = mapper.Map<CourseEntity>(courseDto);
                context.Courses.Add(course);
                await context.SaveChangesAsync();
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
        public async Task<CourseDto> LinkTopicAsync(int courseId, int topicId, int order) {
            try {
                var course = await context.Courses.FindAsync(courseId) ?? throw new EntityNotFoundException { SearchedKey = courseId, SearchedType = typeof(CourseDto) };
                var topic = await context.Topic.FindAsync(topicId) ?? throw new EntityNotFoundException { SearchedType = typeof(TopicDto), SearchedKey = topicId };
                course.Topics.Add(new CourseTopicEntity { Course = course, Topic = topic, CourseId = courseId, TopicId = topicId, Order = order });
                await context.SaveChangesAsync();
                return mapper.Map<CourseDto>(course);
            }
            catch (ServiceException) {
                throw;
            }
            catch (Exception ex) {
                logger.LogError(ex, "Unattended exception linking topic {} to course {}", topicId, courseId);
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
