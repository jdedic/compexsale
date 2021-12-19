using RetailPlatform.Common.Interfaces.Repository;
using RetailPlatform.Common.Interfaces.Service;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RetailPlatform.Core.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        public RoleService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public IEnumerable<SelectListItem> FilterRoleTypes()
        {
            List<SelectListItem> roles = new List<SelectListItem>();

            foreach (var role in _repositoryWrapper.Role.GetRoles())
            {
                SelectListItem item = new SelectListItem
                {
                    Value = role.Name,
                    Text = role.Name
                };
                roles.Add(item);
            }

            return new SelectList(roles, "Value", "Text");
        }
    }
}
