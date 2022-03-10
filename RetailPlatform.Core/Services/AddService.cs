using Microsoft.AspNetCore.Mvc.Rendering;
using RetailPlatform.Common.Entities;
using RetailPlatform.Common.Interfaces.Repository;
using RetailPlatform.Common.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IQueryable<Add> GetAdds()
        {
            return _repositoryWrapper.Add.GetAdds();
        }

        public List<Add> FetchRequests()
        {
            return _repositoryWrapper.Add.FetchRequests();
        }

        public async Task<List<Add>> FetchAddsBySubCategory(string category, long jobTypeId)
        {
            var subcategory = await _repositoryWrapper.SubCategory.FetchSubcategoryByNameAsync(category);
            if(subcategory != null)
            {
                return FilterAddsByJobTypeId(subcategory.Id, jobTypeId);
            }
            return null;
        }

        public List<Add> FilterAdds(long categoryId, string location, string name)
        {
            var adds = _repositoryWrapper.Add.FetchAdds(true);

            if(categoryId != 0)
            {
                adds = adds.Where(m => m.SubCategoryId == categoryId).ToList();
            }

            if (!string.IsNullOrEmpty(location))
            {
                adds = adds.Where(m => m.Place.ToLower().Equals(location.ToLower())).ToList();
            }

            if (!string.IsNullOrEmpty(name))
            {
                adds = adds.Where(m => m.Name.ToLower().Equals(name.ToLower())).ToList();
            }
            return adds;
        }

        public List<Add> FilterAddsByJobTypeId(long categoryId, long jobTypeId)
        {
            var adds = _repositoryWrapper.Add.FetchAddsByJobTypeId(jobTypeId);

            if (categoryId != 0)
            {
                adds = adds.Where(m => m.SubCategoryId == categoryId).ToList();
            }
           
            return adds;
        }

        public async Task RemoveAdd(long id)
        {
            var add = await _repositoryWrapper.Add.GetByIdAsync(id);
            await _repositoryWrapper.Add.Delete(add);
        }

        public async Task CreateAdd(Add model)
        {
            var getPreviousUniqueId = _repositoryWrapper.Add.FetchLastAdd(true);
            var number = string.IsNullOrEmpty(getPreviousUniqueId) ? 0 : Int32.Parse(getPreviousUniqueId);
            number = number + 1;
            model.UniqueId = number.ToString();
            model.CreationDate = DateTime.Now;
            model.JobTypeId = 1;
            await _repositoryWrapper.Add.Create(model);
        }

        public async Task CreateRequest(Add model)
        {
            model.CreationDate = DateTime.Now;
            model.UnitTypeId = 1;
            model.JobTypeId = 2;
            var getPreviousUniqueId = _repositoryWrapper.Add.FetchLastAdd(true);
            var number = string.IsNullOrEmpty(getPreviousUniqueId) ? 0 : Int32.Parse(getPreviousUniqueId);
            number = number + 1;
            model.UniqueId = number.ToString();
            await _repositoryWrapper.Add.Create(model);
        }

        public async Task<Add> GetAddById(long id)
        {
            return await _repositoryWrapper.Add.GetByIdAsync(id);
        }

        public async Task<IEnumerable<SelectListItem>> FilteredCategories(string name)
        {
            List<SelectListItem> roles = new List<SelectListItem>();
            var categories = await _repositoryWrapper.SubCategory.FindAllAsync();
            if (!string.IsNullOrEmpty(name))
            {
                categories = categories.Where(m => m.Name.ToLower().Equals(name.ToLower())).ToList();
            }

            foreach (var role in categories)
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

        public async Task<Add> EditAdd(Add add)
        {
            if (add.Active)
            {
                add.IsMailSent = true;
            }
            await _repositoryWrapper.Add.Update(add);
            return add;
        }

        public async Task EditRequest(Add add)
        {
            await _repositoryWrapper.Add.Update(add);
        }
    }
}
