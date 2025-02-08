using nr.BusinessLayer.Dto.Attachments;

namespace nr.BusinessLayer.Services
{
    /// <summary>
    /// Servizio di gestione degli allegati.
    /// </summary>
    public interface IAttachmentService : IService
    {
        /// <summary>
        /// Aggiunge un allegato.
        /// </summary>
        /// <param name="attachment">L'allegato da aggiungere.</param>
        /// <returns>Le informazioni dell'allegato dopo l'inserimento.</returns>
        /// <remarks>L'allegato restituito non porta con sé il contenuto in byte (se presente) ma solo la chiave per il recupero.</remarks>
        Task<AttachmentWithoutContentDto> AddAsync(AttachmentDto attachment);
        /// <summary>
        /// Elimina un allegato.
        /// </summary>
        /// <param name="attachmentId">La chiave dell'allegato.</param>
        /// <returns>L'ellegato eliminato.</returns>
        /// <remarks>L'allegato restituito non porta con sé il contenuto in byte (se presente) ma solo la chiave per il recupero.</remarks>
        Task<AttachmentWithoutContentDto> DeleteAsync(int attachmentId);
        /// <summary>
        /// Recupera tutti gli allegati.
        /// </summary>
        /// <remarks>Gli allegati restituiti non portano con sé il contenuto in byte (se presente) ma solo la chiave per il recupero.</remarks>
        Task<IEnumerable<AttachmentWithoutContentDto>> GetAllAsync();
        /// <summary>
        /// Recupera un allegato.
        /// </summary>
        /// <param name="attachmentId">La chiave dell'allegato.</param>
        /// <remarks>L'allegato restituito non porta con sé il contenuto in byte (se presente) ma solo la chiave per il recupero.</remarks>
        Task<AttachmentWithoutContentDto> GetByIdAsync(int attachmentId);
        /// <summary>
        /// Recupera il contenuto del documento allegato.
        /// </summary>
        /// <param name="linkId">Chiave del documento.</param>
        /// <returns>Restituisce il documento come url se si tratta di un documento esterno, oppure comprensivo di contenuto in bytes 
        /// se si tratta di un documento embedded.</returns>
        Task<LinkDto> GetLinkByIdAsync(int linkId);
    }
}
