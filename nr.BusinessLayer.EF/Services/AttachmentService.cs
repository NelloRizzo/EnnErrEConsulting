using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using nr.BusinessLayer.Dto.Attachments;
using nr.BusinessLayer.EF.DataLayer;
using nr.BusinessLayer.EF.DataLayer.Entities.Attachments;
using nr.BusinessLayer.Services;
using nr.BusinessLayer.Services.Exceptions;

namespace nr.BusinessLayer.EF.Services
{
    /// <summary>
    /// Servizio di gestione degli allegati.
    /// </summary>
    /// <param name="logger">Logger.</param>
    /// <param name="context">Contesto di database.</param>
    public class AttachmentService(ILogger<Service> logger, ApplicationDBContext context) : Service(), IAttachmentService
    {
        /// <inheritdoc/>
        /// <exception cref="ServiceException"></exception>
        public async Task<AttachmentWithoutContentDto> AddAsync(AttachmentDto attachmentDto) {
            try {
                var attachment = mapper.Map<AttachmentEntity>(attachmentDto);
                var trans = await context.Database.BeginTransactionAsync();
                context.Links.Add(attachment.Link);
                await context.SaveChangesAsync();
                context.Attachments.Add(attachment);
                await context.SaveChangesAsync();
                await trans.CommitAsync();

                return mapper.Map<AttachmentWithoutContentDto>(attachment);
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception adding attachment");
                throw new ServiceException(innerException: ex);
            }
        }

        /// <inheritdoc/>
        /// <exception cref="ServiceException"></exception>
        public async Task<AttachmentWithoutContentDto> DeleteAsync(int attachmentId) {
            try {
                var entity = await context.Attachments.FindAsync(attachmentId) ?? throw new EntityNotFoundException { SearchedKey = attachmentId, SearchedType = typeof(AttachmentDto) };
                context.Attachments.Remove(entity);
                await context.SaveChangesAsync();
                return mapper.Map<AttachmentWithoutContentDto>(entity);
            }
            catch (ServiceException) {
                throw;
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception deleting attachment by id {}", attachmentId);
                throw new ServiceException(innerException: ex);
            }
        }

        /// <inheritdoc/>
        /// <exception cref="ServiceException"></exception>
        public async Task<IEnumerable<AttachmentWithoutContentDto>> GetAllAsync() {
            try {
                return mapper.Map<IEnumerable<AttachmentWithoutContentDto>>(await context.Attachments.ToListAsync());
            }
            catch (Exception ex) {
                logger.LogError(ex, "Unattended exception retrieving all attachments");
                throw new ServiceException(innerException: ex);
            }
        }

        /// <inheritdoc/>
        /// <exception cref="ServiceException"></exception>
        public async Task<AttachmentWithoutContentDto> GetByIdAsync(int attachmentId) {
            try {
                var entity = await context.Attachments.FindAsync(attachmentId) ?? throw new EntityNotFoundException { SearchedKey = attachmentId, SearchedType = typeof(AttachmentDto) };
                return mapper.Map<AttachmentWithoutContentDto>(entity);
            }
            catch (ServiceException) {
                throw;
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception getting attachment by id {}", attachmentId);
                throw new ServiceException(innerException: ex);
            }
        }

        /// <inheritdoc/>
        /// <exception cref="ServiceException"></exception>
        public async Task<LinkDto> GetLinkByIdAsync(int linkId) {
            try {
                var entity = await context.Links.FindAsync(linkId) ?? throw new EntityNotFoundException { SearchedKey = linkId, SearchedType = typeof(LinkDto) };
                return mapper.Map<LinkDto>(entity);
            }
            catch (ServiceException) {
                throw;
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception getting link by id {}", linkId);
                throw new ServiceException(innerException: ex);
            }
        }

    }
}
