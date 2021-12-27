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
        public ICategorySubCategoryRepository CategorySubCategory { get; set; }
        public IAddRepository Add { get; set; }

        public RepositoryWrapper(RetailContext retailContext, IUserRepository user, IRoleRepository role,
            IAddRepository add, ICategoryRepository category, ISubCategoryRepository subCategory, 
            ICategorySubCategoryRepository categorySubCategory)
        {
            _retailContext = retailContext;
            User = user;
            Role = role;
            Add = add;
            Category = category;
            SubCategory = subCategory;
            CategorySubCategory = categorySubCategory;
        }

    }
}
