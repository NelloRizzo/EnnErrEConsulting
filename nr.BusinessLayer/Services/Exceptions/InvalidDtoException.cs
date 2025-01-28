using nr.BusinessLayer.Dto;

namespace nr.BusinessLayer.Services.Exceptions
{
    /// <summary>
    /// Comunica che il DTO non ha superato la validazione.
    /// </summary>
    /// <inheritdoc/>
    public class InvalidDtoException(string? message = null, Exception? innerException = null) : ServiceException(message, innerException)
    {
        /// <summary>
        /// Il DTO che non ha superato la validazione.
        /// </summary>
        public BaseDto? InvalidDto { get; set; }
    }
}
