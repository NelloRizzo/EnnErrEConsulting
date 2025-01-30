using Castle.Core.Logging;
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
    public class TopicService(ApplicationDBContext context, ILogger<TopicService> logger) : Service, ITopicService
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

        public Task<TopicDto> DeleteAsync(int topicId) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TopicDto>> GetAllAsync() {
            throw new NotImplementedException();
        }

        public Task<TopicDto> GetAsync(int topicId) {
            throw new NotImplementedException();
        }

        public async Task<TopicDto> UpdateAsync(int topicId, TopicDto topicDto) {
            try {
                if (!topicDto.IsValid()) throw new InvalidDtoException { InvalidDto = topicDto };
                var topic = await context.Topics.FindAsync(topicId) ?? throw new EntityNotFoundException { SearchedKey = topicId, SearchedType = typeof(TopicDto) };
                

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
    }
}
