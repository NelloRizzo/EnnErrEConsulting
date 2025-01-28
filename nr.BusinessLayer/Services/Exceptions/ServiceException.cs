namespace nr.BusinessLayer.Services.Exceptions
{
    /// <summary>
    /// Eccezione che comunica l'impossibilità di completare un'operazione nel business layer.
    /// </summary>
    /// <param name="message">Messaggio di errore.</param>
    /// <param name="innerException">Eccezione interna.</param>
    public class ServiceException(string? message = "Service exception", Exception? innerException = null) : Exception(message, innerException)
    {
    }
}
