namespace nr.PresentationLayer.Controllers.Api.Models.Customers
{
    /// <summary>
    /// Body per la ricerca tramite l'email.
    /// </summary>
    public class SearchByEmailModel
    {
        /// <summary>
        /// La parte dell'email cercata.
        /// </summary>
        public required string Email { get; set; }
    }
    /// <summary>
    /// Body per la ricerca tramite nome.
    /// </summary>

    public class SearchByNameModel
    {
        /// <summary>
        /// Parte del nome da cercare.
        /// </summary>
        public required string Name { get; set; }
    }
    /// <summary>
    /// Body per la ricerca tramite città.
    /// </summary>
    public class SearchByCityModel
    {
        /// <summary>
        /// Parte della città.
        /// </summary>
        public string? City { get; set; }
        /// <summary>
        /// Parte della provincia.
        /// </summary>
        public string? Province { get; set; }
    }
}
