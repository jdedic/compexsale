
namespace RetailPlatform.Common.Interfaces.Repository
{
    public interface IRepositoryWrapper
    {
       IUserRepository User { get; }
       IRoleRepository Role { get; }
       IAddRepository Add { get; }
       ICategoryRepository Category { get; }
       ISubCategoryRepository SubCategory { get; }
       IProfileRepository Profile { get; }
       IProfileCategoryRepository ProfileCategory { get; }
    }
}
