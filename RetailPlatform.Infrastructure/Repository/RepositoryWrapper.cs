using RetailPlatform.Common.Interfaces.Repository;
using RetailPlatform.Infrastructure.Data;

namespace RetailPlatform.Infrastructure.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly RetailContext _retailContext;
        public IUserRepository User { get; set; }
        public IRoleRepository Role { get; set; }
        public RepositoryWrapper(RetailContext retailContext, IUserRepository user, IRoleRepository role)
        {
            _retailContext = retailContext;
            User = user;
            Role = role;
        }

    }
}
