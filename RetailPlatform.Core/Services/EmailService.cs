using RetailPlatform.Common.Interfaces.Repository;
using RetailPlatform.Common.Interfaces.Service;

namespace RetailPlatform.Core.Services
{
    public class EmailService : IEmailService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public EmailService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
    }
}
