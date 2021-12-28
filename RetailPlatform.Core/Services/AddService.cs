using Microsoft.AspNetCore.Mvc.Rendering;
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

        public async Task CreateAdd(Add model)
        {
            model.ProfileId = 1;
            model.CreationDate = DateTime.Now;
            model.UniqueId = (Guid.NewGuid().ToString()).Substring(0, 7);
            
            await _repositoryWrapper.Add.Create(model);
        }

        public async Task<Add> GetAddById(long id)
        {
            return await _repositoryWrapper.Add.GetByIdAsync(id);
        }

        public IEnumerable<SelectListItem> FilteredCategories()
        {
            List<SelectListItem> roles = new List<SelectListItem>();

            foreach (var role in _repositoryWrapper.Add.GetCategories())
            {
                SelectListItem item = new SelectListItem
                {
                    Value = role.Id.ToString(),
                    Text = role.Name
                };
                roles.Add(item);
            }

            return new SelectList(roles, "Value", "Text");
        }
    }
}
