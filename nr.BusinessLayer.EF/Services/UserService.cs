using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using nr.BusinessLayer.Dto.Operators;
using nr.BusinessLayer.EF.DataLayer;
using nr.BusinessLayer.EF.DataLayer.Entities.Operators;
using nr.BusinessLayer.Services;
using nr.BusinessLayer.Services.Exceptions;
using nr.Validation;

namespace nr.BusinessLayer.EF.Services
{
    /// <inheritdoc/>
    public class UserService(ILogger<Service> logger, ApplicationDBContext context) : Service(), IUserService
    {

        /// <inheritdoc/>
        public async Task<bool> AddUserToRoleAsync(string username, string roleName) {
            try {
                var user = await context.Users.SingleAsync(u => u.Email == username) ?? throw new EntityNotFoundException { SearchedKey = username, SearchedType = typeof(UserDto) };
                var role = await context.Roles.SingleOrDefaultAsync(r => r.RoleName.Equals(roleName.ToLower())) ?? await AddRoleAsync(roleName);
                user.Roles.Add(new UserRoleRelationship { Role = role, User = user });
                await context.SaveChangesAsync();
                return true;
            }
            catch (ServiceException) {
                throw;
            }
            catch (Exception ex) {
                logger.LogError(ex, "Unattended exception in {}", nameof(AddUserToRoleAsync));
                throw new ServiceException(innerException: ex);
            }
        }

        /// <inheritdoc/>
        private async Task<RoleEntity> AddRoleAsync(string roleName) {
            try {
                var role = new RoleEntity { RoleName = roleName.ToLower() };
                context.Roles.Add(role);
                await context.SaveChangesAsync();
                return role;
            }
            catch (Exception ex) {
                logger.LogError(ex, "Unattended exception in {}", nameof(AddUserToRoleAsync));
                throw new ServiceException(innerException: ex);
            }
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteRoleAsync(string roleName) {
            try {
                var role = await context.Roles.SingleOrDefaultAsync(r => r.RoleName.Equals(roleName, StringComparison.InvariantCultureIgnoreCase));
                if (role == null) return true;
                context.Roles.Remove(role);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) {
                logger.LogError(ex, "Unattended exception in {}", nameof(DeleteRoleAsync));
                throw new ServiceException(innerException: ex);
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<RoleDto>> GetRolesAsync() {
            try {
                return await context.Roles.Select(r => new RoleDto { RoleName = r.RoleName, Id = r.Id }).ToListAsync();
            }
            catch (Exception ex) {
                logger.LogError(ex, "Unattended exception in {}", nameof(GetRolesAsync));
                throw new ServiceException(innerException: ex);
            }
        }

        /// <inheritdoc/>
        public async Task<UserDto?> GetUserByUsernameAsync(string username) {
            try {
                var user = await context.Users.SingleAsync(u => u.Email == username);
                if (user == null) return null;
                return mapper.Map<UserDto>(user);
            }
            catch (Exception ex) {
                logger.LogError(ex, "Unattended exception in {}", nameof(GetUserByUsernameAsync));
                throw new ServiceException(innerException: ex);
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<UserDto>> GetUsersAsync() {
            try {
                return mapper.Map<IEnumerable<UserDto>>(await context.Users.ToListAsync());
            }
            catch (Exception ex) {
                logger.LogError(ex, "Unattended exception in {}", nameof(GetUsersAsync));
                throw new ServiceException(innerException: ex);
            }
        }

        /// <inheritdoc/>
        public async Task<bool> IsUserInRoleAsync(string username, string roleName) {
            try {
                var user = await context.Users.SingleAsync(u => u.Email == username);
                return user.Roles.Any(ur => ur.Role.RoleName.Equals(roleName, StringComparison.InvariantCultureIgnoreCase));
            }
            catch (Exception ex) {
                logger.LogError(ex, "Unattended exception in {}", nameof(IsUserInRoleAsync));
                throw new ServiceException(innerException: ex);
            }
        }

        /// <inheritdoc/>
        public async Task<UserDto?> LoginUserAsync(string username, string password) {
            try {
                var user = await context.Users.SingleOrDefaultAsync(u => u.Email == username && u.Password == password);
                return mapper.Map<UserDto?>(user);
            }
            catch (Exception ex) {
                logger.LogError(ex, "Unattended exception in {}", nameof(LoginUserAsync));
                throw new ServiceException(innerException: ex);
            }
        }

        /// <inheritdoc/>
        public async Task<UserDto?> LogoutUserAsync(string username) {
            logger.LogInformation("Method {} is not implemented as significant", nameof(LogoutUserAsync));
            try {
                var user = await context.Users.SingleOrDefaultAsync(u => u.Email == username);
                return mapper.Map<UserDto?>(user);
            }
            catch (Exception ex) {
                logger.LogError(ex, "Unattended exception in {}", nameof(LogoutUserAsync));
                throw new ServiceException(innerException: ex);
            }
        }

        /// <inheritdoc/>
        public async Task<UserDto?> RegisterUserAsync(UserDto user) {
            try {
                if (!user.IsValid()) throw new InvalidDtoException { InvalidDto = user };
                var trans = await context.Database.BeginTransactionAsync();
                var u = new UserEntity { Email = user.Email, Password = user.Password };
                context.Users.Add(u);
                await context.SaveChangesAsync();
                foreach (var role in user.Roles)
                    await AddUserToRoleAsync(user.Email, role);
                await trans.CommitAsync();
                return mapper.Map<UserDto?>(user);
            }
            catch (ServiceException) {
                throw;
            }
            catch (Exception ex) {
                logger.LogError(ex, "Unattended exception in {}", nameof(RegisterUserAsync));
                throw new ServiceException(innerException: ex);
            }
        }

        /// <inheritdoc/>
        public async Task<bool> RemoveUserFromRoleAsync(string username, string roleName) {
            try {
                var user = await context.Users.SingleAsync(u => u.Email == username) ?? throw new EntityNotFoundException { SearchedKey = username, SearchedType = typeof(UserDto) };
                var role = user.Roles.SingleOrDefault(ur => ur.Role.RoleName.Equals(roleName));
                if (role == null) return true;
                user.Roles.Remove(role);
                await context.SaveChangesAsync();
                return true;
            }
            catch (ServiceException) {
                throw;
            }
            catch (Exception ex) {
                logger.LogError(ex, "Unattended exception in {}", nameof(RemoveUserFromRoleAsync));
                throw new ServiceException(innerException: ex);
            }
        }
    }
}
