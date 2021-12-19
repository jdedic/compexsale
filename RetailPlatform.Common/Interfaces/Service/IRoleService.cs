using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace RetailPlatform.Common.Interfaces.Service
{
    public interface IRoleService
    {
        IEnumerable<SelectListItem> FilterRoleTypes();
    }
}
