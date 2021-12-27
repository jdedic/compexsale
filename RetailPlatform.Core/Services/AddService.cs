using RetailPlatform.Common.Entities;
using RetailPlatform.Common.Interfaces.Repository;
using RetailPlatform.Common.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
