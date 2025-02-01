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
    /// <summary>
    /// Servizio di gestione degli argomenti collegati ai corsi.
    /// </summary>
    /// <param name="logger">Logger.</param>
    /// <param name="context">Contesto di database.</param>
    public class TopicService(ILogger<TopicService> logger, ApplicationDBContext context) : Service, ITopicService
    {
        /// <inheritdoc/>
        /// <exception cref="InvalidDtoException"></exception>
        /// <exception cref="ServiceException"></exception>
        public async Task<TopicDto> AddAsync(TopicDto topicDto) {
            try {
                if (!topicDto.IsValid()) throw new InvalidDtoException { InvalidDto = topicDto };
                var topic = mapper.Map<TopicEntity>(topicDto);
                context.Topics.Add(topic);
                await context.SaveChangesAsync();
                return mapper.Map<TopicDto>(topic);
            }
            catch (ServiceException) {
                throw;
            }
            catch (Exception ex) {
                logger.LogError(ex, "Unattended exception adding topic");
                throw new ServiceException(innerException: ex);
            }
        }
        /// <inheritdoc/>
        /// <exception cref="EntityNotFoundException"></exception>
        /// <exception cref="ServiceException"></exception>
        public async Task<TopicDto> DeleteAsync(int topicId) {
            try {
                var topic = await context.Topics.FindAsync(topicId) ?? throw new EntityNotFoundException { SearchedKey = topicId, SearchedType = typeof(TopicDto) };
                context.Topics.Remove(topic);
                return mapper.Map<TopicDto>(topic);
            }
            catch (ServiceException) {
                throw;
            }
            catch (Exception ex) {
                logger.LogError(ex, "Unattended exception deleting topic {}", topicId);
                throw new ServiceException(innerException: ex);
            }

        }

        /// <inheritdoc/>
        /// <exception cref="ServiceException"></exception>
        public async Task<IEnumerable<TopicDto>> GetAllAsync() {
            try {
                var result = await context.Topics.ToListAsync();
                return mapper.Map<IEnumerable<TopicDto>>(result);
            }
            catch (Exception ex) {
                logger.LogError(ex, "Unattended exception retrieving all topics");
                throw new ServiceException(innerException: ex);
            }
        }

        /// <inheritdoc/>
        /// <exception cref="ServiceException"></exception>
        public async Task<TopicDto?> GetAsync(int topicId) {
            try {
                var result = await context.Topics.FindAsync(topicId);
                return mapper.Map<TopicDto>(result);
            }
            catch (Exception ex) {
                logger.LogError(ex, "Unattended exception retrieving all topics");
                throw new ServiceException(innerException: ex);
            }
        }
        /// <inheritdoc/>
        /// <exception cref="EntityNotFoundException"></exception>
        /// <exception cref="ServiceException"></exception>
        public async Task<TopicDto> UpdateAsync(int topicId, string? summary, string? description) {
            try {
                var topic = await context.Topics.FindAsync(topicId) ?? throw new EntityNotFoundException { SearchedKey = topicId, SearchedType = typeof(TopicDto) };
                if (description != null) topic.Description = description;
                if (summary != null) topic.Abstract = summary;
                await context.SaveChangesAsync();
                return mapper.Map<TopicDto>(topic);
            }
            catch (ServiceException) {
                throw;
            }
            catch (Exception ex) {
                logger.LogError(ex, "Unattended exception updating topic {}", topicId);
                throw new ServiceException(innerException: ex);
            }
        }
    }
}
