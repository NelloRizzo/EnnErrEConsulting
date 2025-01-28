namespace nr.BusinessLayer.Services.Exceptions
{
    public class EntityNotFoundException(string? message = "Service exception", Exception? innerException = null) : ServiceException(message, innerException)
    {
        public object? SearchedKey { get; set; }
        public Type? SearchedType { get; set; }
    }
}
