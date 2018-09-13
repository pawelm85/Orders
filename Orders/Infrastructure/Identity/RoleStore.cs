using Domain.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Infrastructure.Identity
{
    public sealed class RoleStore : Store<Role>, IRoleStore<Role>
    {
        public Task CreateAsync(Role role)
        {
            Add(role);
            return Task.FromResult(IdentityResult.Success);
        }

        public Task DeleteAsync(Role role)
        {
            Delete(role);
            return Task.FromResult(IdentityResult.Success);

        }
 

        public void Dispose()
        {
            //Nothing to do
        }

        public Task<Role> FindByIdAsync(string roleId)
      => Task.FromResult(Get(roleId));

        public Task<Role> FindByNameAsync(string roleName)
      => Task.FromResult(Find(r => string.Equals(r.Name, roleName, StringComparison.OrdinalIgnoreCase)).First());

        public Task UpdateAsync(Role role)
        {
            // In-memory store, nothing to do here
                return Task.FromResult(IdentityResult.Success);
        }
    }
}
