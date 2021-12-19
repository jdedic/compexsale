
namespace RetailPlatform.Common.Interfaces.Repository
{
    public interface IRepositoryWrapper
    {
       IUserRepository User { get; }
       IRoleRepository Role { get; }
    }
}
