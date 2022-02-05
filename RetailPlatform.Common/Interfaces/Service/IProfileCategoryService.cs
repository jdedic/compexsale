using System.Threading.Tasks;

namespace RetailPlatform.Common.Interfaces.Service
{
    public interface IProfileCategoryService
    {
        Task RemoveProfileCategories(long profileId);
    }
}
