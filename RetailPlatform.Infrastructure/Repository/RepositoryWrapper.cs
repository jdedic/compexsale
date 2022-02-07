using RetailPlatform.Common.Interfaces.Repository;
using RetailPlatform.Infrastructure.Data;

namespace RetailPlatform.Infrastructure.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly RetailContext _retailContext;
        public IUserRepository User { get; set; }
        public IRoleRepository Role { get; set; }
        public ICategoryRepository Category { get; set; }
        public ISubCategoryRepository SubCategory { get; set; }
        public IAddRepository Add { get; set; }
        public IProfileRepository Profile { get; set; }
        public IProfileCategoryRepository ProfileCategory { get; set; }

        public RepositoryWrapper(RetailContext retailContext, IUserRepository user, IRoleRepository role,
            IAddRepository add, ICategoryRepository category, ISubCategoryRepository subCategory,
            IProfileRepository profile, IProfileCategoryRepository profileCategory)
        {
            _retailContext = retailContext;
            User = user;
            Role = role;
            Add = add;
            Category = category;
            SubCategory = subCategory;
            Profile = profile;
            ProfileCategory = profileCategory;
        }

    }
}
