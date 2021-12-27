using RetailPlatform.Common.Entities;
using RetailPlatform.Common.Interfaces.Repository;
using RetailPlatform.Common.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RetailPlatform.Core.Services
{
    public class AddService : IAddService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public AddService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public IEnumerable<Add> FetchActiveAdds()
        {
            return _repositoryWrapper.Add.FetchActiveAdds();
        }

        public async Task RemoveAdd(long id)
        {
            var add = await _repositoryWrapper.Add.GetByIdAsync(id);
            await _repositoryWrapper.Add.Delete(add);
        }
    }
}
