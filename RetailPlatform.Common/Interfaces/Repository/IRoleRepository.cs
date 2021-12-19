using RetailPlatform.Common.Entities;
using System.Collections.Generic;

namespace RetailPlatform.Common.Interfaces.Repository
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        List<Role> GetRoles();
        long GetRoleByName(string name);
    }
}
