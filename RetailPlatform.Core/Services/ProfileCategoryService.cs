using RetailPlatform.Common.Interfaces.Repository;
using RetailPlatform.Common.Interfaces.Service;
using System.Threading.Tasks;

namespace RetailPlatform.Core.Services
{
    public class ProfileCategoryService : IProfileCategoryService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ProfileCategoryService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task RemoveProfileCategories(long profileId)
        {
            var categories = await _repositoryWrapper.ProfileCategory.GetProfileCategoriesByProfileId(profileId);
            foreach(var item in categories)
            {
                await _repositoryWrapper.ProfileCategory.Delete(item);
            }
        }
    }
}
