namespace nr.BusinessLayer.Services.Exceptions
{
    public class ServiceException(string? message = "Service exception", Exception? innerException = null) : Exception(message, innerException)
    {
    }
}
