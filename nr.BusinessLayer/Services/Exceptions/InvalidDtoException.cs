using nr.BusinessLayer.Dto;

namespace nr.BusinessLayer.Services.Exceptions
{
    public class InvalidDtoException(string? message = null, Exception? innerException = null) : ServiceException(message, innerException)
    {
        public BaseDto? InvalidDto { get; set; }
    }
}
