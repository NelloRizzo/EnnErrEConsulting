using nr.BusinessLayer.Dto.Operators;

namespace nr.BusinessLayer.Services
{
    /// <summary>
    /// Servizio per la gestione degli utenti.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Registra un utente.
        /// </summary>
        /// <param name="user">I dati dell'utente.</param>
        /// <returns>L'utente dopo la registrazione.</returns>
        Task<UserDto?> RegisterUserAsync(UserDto user);
        /// <summary>
        /// Effettua il login.
        /// </summary>
        /// <param name="username">Lo username.</param>
        /// <param name="password">La password.</param>
        /// <returns>I dati dell'utente che ha effettuato il login.</returns>
        Task<UserDto?> LoginUserAsync(string username, string password);
        /// <remarks>Non implementato in questa versione.</remarks>
        Task<UserDto?> LogoutUserAsync(string username);
        /// <summary>
        /// Recupera un utente a partire dallo username.
        /// </summary>
        /// <param name="username">Username da cercare.</param>
        /// <returns>L'utente corrispondente allo username passato come parametro.</returns>
        Task<UserDto?> GetUserByUsernameAsync(string username);
        /// <summary>
        /// Recupera un utente a partire dallo username.
        /// </summary>
        /// <param name="userId">La chiave dell'utente.</param>
        /// <returns>L'utente corrispondente alla chiave passata come parametro.</returns>
        Task<UserDto> GetUserByIdAsync(int userId);
        /// <summary>
        /// Recupera l'elenco degli utenti.
        /// </summary>
        /// <returns>Tutti gli utenti.</returns>
        Task<IEnumerable<UserDto>> GetUsersAsync();
        /// <summary>
        /// Aggiunge un utente ad un ruolo.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <param name="roleName">Nome del ruolo.</param>
        /// <returns>Valore che indica se l'operazione è andata a buon fine.</returns>
        Task<bool> AddUserToRoleAsync(string username, string roleName);
        /// <summary>
        /// Rimuove un utente da un ruolo.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <param name="roleName">Nome del ruolo.</param>
        /// <returns>Valore che indica se l'operazione è andata a buon fine.</returns>
        Task<bool> RemoveUserFromRoleAsync(string username, string roleName);
        /// <summary>
        /// Controlla se un utente è associato ad un ruolo.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <param name="roleName">Nome del ruolo.</param>
        /// <returns>Valore che indica se l'utente è associato al ruolo.</returns>
        Task<bool> IsUserInRoleAsync(string username, string roleName);
        /// <summary>
        /// Ottiene l'elenco dei ruoli.
        /// </summary>
        /// <returns>Tutti i ruoli.</returns>
        Task<IEnumerable<RoleDto>> GetRolesAsync();
        /// <summary>
        /// Elimina un ruolo.
        /// </summary>
        /// <param name="roleName">Nome del ruolo da eliminare.</param>
        /// <returns>Valore che indica se l'operazione è andata a buon fine.</returns>
        Task<bool> DeleteRoleAsync(string roleName);
    }
}
