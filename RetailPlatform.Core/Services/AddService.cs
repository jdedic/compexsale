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

        public List<Add> FetchAdds(bool active)
        {
            return _repositoryWrapper.Add.FetchAdds(active);
        }

        public async Task RemoveAdd(long id)
        {
            var add = await _repositoryWrapper.Add.GetByIdAsync(id);
            await _repositoryWrapper.Add.Delete(add);
        }

        public async Task CreateAdd(Add model)
        {
            model.CreationDate = DateTime.Now;
            model.UniqueId = (Guid.NewGuid().ToString()).Substring(0, 7);
            await _repositoryWrapper.Add.Create(model);
        }

        public async Task<Add> GetAddById(long id)
        {
            return await _repositoryWrapper.Add.GetByIdAsync(id);
        }

        public async Task<IEnumerable<SelectListItem>> FilteredCategories()
        {
            List<SelectListItem> roles = new List<SelectListItem>();

            foreach (var role in await _repositoryWrapper.SubCategory.FindAllAsync())
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

        public async Task<IEnumerable<SelectListItem>> GetUnits()
        {
            List<SelectListItem> cities = new List<SelectListItem>();

            foreach (var unit in await _repositoryWrapper.Add.GetUnits())
            {
                SelectListItem item = new SelectListItem
                {
                    Value = unit.Id.ToString(),
                    Text = unit.Name
                };
                cities.Add(item);
            }

            return new SelectList(cities, "Value", "Text");
        }

        public async Task<IEnumerable<SelectListItem>> GetJobTypes()
        {
            List<SelectListItem> cities = new List<SelectListItem>();

            foreach (var unit in await _repositoryWrapper.Add.GetJobTypes())
            {
                SelectListItem item = new SelectListItem
                {
                    Value = unit.Id.ToString(),
                    Text = unit.Name
                };
                cities.Add(item);
            }

            return new SelectList(cities, "Value", "Text");
        }

        public async Task EditAdd(Add add)
        {
            await _repositoryWrapper.Add.Update(add);
        }
    }
}
