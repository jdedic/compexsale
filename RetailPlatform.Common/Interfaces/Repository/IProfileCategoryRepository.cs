using RetailPlatform.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RetailPlatform.Common.Interfaces.Repository
{
    public interface IProfileCategoryRepository : IBaseRepository<ProfileCategory>
    {
        Task<List<ProfileCategory>> GetProfileCategoriesByProfileId(long profileId);
    }
}
