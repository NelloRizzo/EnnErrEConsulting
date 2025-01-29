using nr.BusinessLayer.Dto.Customers;
using nr.BusinessLayer.Dto.Customers.Addresses;

namespace nr.BusinessLayer.Services
{
    /// <summary>
    /// Servizio di gestione dei clienti.
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        /// Recupera tutti i clienti.
        /// </summary>
        /// <returns>Tutti i clienti.</returns>
        Task<IEnumerable<CustomerDto>> GetAllAsync();
        /// <summary>
        /// Recupera i clienti attraverso il nome.
        /// </summary>
        /// <param name="name">Parte del nome da cercare.</param>
        /// <returns>L'elenco dei clienti il cui nome corrisponde al parametro passato.</returns>
        Task<IEnumerable<CustomerDto>> GetAllByNameContainsAsync(string name);
        /// <summary>
        /// Recupera i clienti attraverso la città e/o la provincia.
        /// </summary>
        /// <param name="city">La città.</param>
        /// <param name="province">La provincia.</param>
        /// <returns>L'elenco dei clienti che risiedono nella città indicata dai parametri.</returns>
        Task<IEnumerable<CustomerDto>> GetAllByCityAndProvinceAsync(string? city, string? province);
        /// <summary>
        /// Recupera i clienti tramite parte dell'email.
        /// </summary>
        /// <param name="email">L'email.</param>
        /// <returns>Tutti i clienti la cui email corrisponde al parametro passato.</returns>
        Task<IEnumerable<CustomerDto>> GetAllByEmailContainsAsync(string email);
        /// <summary>
        /// Recupera tutte le aziende.
        /// </summary>
        /// <returns>Tutte le aziende.</returns>
        Task<IEnumerable<CustomerDto>> GetCompaniesAsync();
        /// <summary>
        /// Recupera tutti i clienti privati.
        /// </summary>
        /// <returns>Tutti i clienti privati.</returns>
        Task<IEnumerable<CustomerDto>> GetPeopleAsync();
        /// <summary>
        /// Registra un cliente privato.
        /// </summary>
        /// <param name="personDto">I dati del cliente.</param>
        /// <returns>Il cliente dopo la registrazione.</returns>
        Task<PersonDto> RegisterAsync(PersonDto personDto);
        /// <summary>
        /// Registra un'azienda.
        /// </summary>
        /// <param name="companyDto">I dati dell'azienda.</param>
        /// <returns>L'azienda dopo la registrazione.</returns>
        Task<CompanyDto> RegisterAsync(CompanyDto companyDto);
        /// <summary>
        /// Recupera un cliente.
        /// </summary>
        /// <param name="id">La chiave del cliente.</param>
        /// <returns>Il cliente che corrisponde alla chiave oppure il valore <strong>null</strong>.</returns>
        Task<CustomerDto?> GetByIdAsync(int id);
        /// <summary>
        /// Aggiunge un indirizzo ad un cliente.
        /// </summary>
        /// <param name="customerId">La chiave del cliente.</param>
        /// <param name="addressDto">I dati dell'indirizzo da aggiungere.</param>
        /// <returns>I dati del cliente dopo l'aggiunta dell'indirizzo.</returns>
        Task<CustomerDto> AddAddressAsync(int customerId, AddressDto addressDto);
        /// <summary>
        /// Rimuove un indirizzo da un cliente.
        /// </summary>
        /// <param name="customerId">La chiave del cliente.</param>
        /// <param name="addressId">La chiave dell'indirizzo.</param>
        /// <returns>I dati del cliente dopo l'aggiunta dell'indirizzo.</returns>
        Task<CustomerDto> RemoveAddressAsync(int customerId, int addressId);
    }
}
