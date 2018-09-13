using Domain.Identity;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public sealed class UserStore : Store<User>, IUserPasswordStore<User>, IUserRoleStore<User>
    {
        private readonly RoleStore _roles;

        public UserStore(RoleStore roleStore)
        {
            _roles = roleStore;
        }

        public Task AddToRoleAsync(User user, string roleName)
        {
            var role = _roles.Find(r => string.Equals(r.Name, roleName, StringComparison.OrdinalIgnoreCase))
                .ToList()
                .First();

            role.AddUser(user);
            return Task.CompletedTask;
        }

        public Task CreateAsync(User user)
        {
            Add(user);
            return Task.FromResult(IdentityResult.Success);
        }

        public Task DeleteAsync(User user)
        {
            Delete(user);
            return Task.FromResult(IdentityResult.Success);
        }

        public Task<User> FindByIdAsync(string userId)
            => Task.FromResult(Get(userId));

        public Task<User> FindByNameAsync(string userName)
        {
            var user = Find(u => string.Equals(u.UserName, userName, StringComparison.OrdinalIgnoreCase))
                .FirstOrDefault();

            return Task.FromResult(user);
        }
        public Task<string> GetNormalizedUserNameAsync(User user)
            => Task.FromResult(user.UserName?.ToUpper());

        public Task<string> GetPasswordHashAsync(User user)
            => Task.FromResult(user.Password);

        public Task<IList<string>> GetRolesAsync(User user)
            => Task.FromResult((IList<string>)_roles
                .Find(r => r.UsersInRole.Any(ur => string.Equals(ur.Id, user.Id, StringComparison.OrdinalIgnoreCase)))
                .Select(r => r.Name)
                .ToList());

        public Task<string> GetUserIdAsync(User user)
            => Task.FromResult(user.Id.ToString());

        public Task<string> GetUserNameAsync(User user)
            => Task.FromResult(user.UserName);

        public Task<IList<User>> GetUsersInRoleAsync(string roleName)
            => Task.FromResult((IList<User>)_roles.Find(r => string.Equals(r.Name, roleName, StringComparison.OrdinalIgnoreCase))
                .First()
                .UsersInRole);

        public Task<bool> HasPasswordAsync(User user)
            => Task.FromResult(!string.IsNullOrWhiteSpace(user.Password));

        public Task<bool> IsInRoleAsync(User user, string roleName)
            => Task.FromResult(_roles
                .Find(r => string.Equals(r.Name, roleName, StringComparison.OrdinalIgnoreCase))
                .ToList()
                .First()
                .UsersInRole
                .Any(u => string.Equals(u.Id, user.Id, StringComparison.OrdinalIgnoreCase)));

        public Task RemoveFromRoleAsync(User user, string roleName)
        {
            var role = _roles.Find(r => string.Equals(r.Name, roleName, StringComparison.OrdinalIgnoreCase))
                .First();

            role.RemoveUser(user);
            return Task.CompletedTask;
        }

        public Task SetNormalizedUserNameAsync(User user, string normalizedName)
            => Task.CompletedTask;

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            user.Password = passwordHash;
            return Task.CompletedTask;
        }

        public Task SetUserNameAsync(User user, string userName)
        {
            user.UserName = userName;
            return Task.CompletedTask;
        }

        public Task UpdateAsync(User user)
        {
            // Nothing to do, in memory collection
            return Task.FromResult(IdentityResult.Success);
        }

        public void Dispose()
        {
            // Nothing to do
        }

       
    }
}
