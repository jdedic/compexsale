using RetailPlatform.Common.Entities;
using RetailPlatform.Common.Interfaces.Repository;
using RetailPlatform.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace RetailPlatform.Infrastructure.Repository
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(RetailContext dbContext) : base(dbContext)
        {

        }

        public List<Role> GetRoles()
        {
            return _dbContext.Roles.ToList();
        }

        public long GetRoleByName(string name)
        {
            return _dbContext.Roles.Where(m => m.Name.Equals(name)).Select(m => m.Id).FirstOrDefault();
        }
    }
}
