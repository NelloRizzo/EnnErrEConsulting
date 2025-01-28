namespace nr.BusinessLayer.Services.Exceptions
{
    /// <summary>
    /// Entità non trovata.
    /// </summary>
    /// <inheritdoc/>
    public class EntityNotFoundException(string? message = "Service exception", Exception? innerException = null) : ServiceException(message, innerException)
    {
        /// <summary>
        /// Chiave utilizzata per la ricerca.
        /// </summary>
        public object? SearchedKey { get; set; }
        /// <summary>
        /// Tipo del DTO cercato.
        /// </summary>
        public Type? SearchedType { get; set; }
    }
}
