using nr.BusinessLayer.Dto.Operators;

namespace nr.BusinessLayer.Services
{
    public interface IUserService
    {
        Task<UserDto?> RegisterUserAsync(UserDto user);
        Task<UserDto?> LoginUserAsync(string username, string password);
        Task<UserDto?> LogoutUserAsync(string username);
        Task<UserDto?> GetUserByUsernameAsync(string username);
        Task<IEnumerable<UserDto>> GetUsersAsync();
        Task<bool> AddUserToRoleAsync(string username, string roleName);
        Task<bool> RemoveUserFromRoleAsync(string username, string roleName);
        Task<bool> IsUserInRoleAsync(string username, string roleName);
        Task<IEnumerable<RoleDto>> GetRolesAsync();
        Task<bool> DeleteRoleAsync(string roleName);
    }
}
