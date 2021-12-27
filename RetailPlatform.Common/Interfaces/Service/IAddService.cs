using RetailPlatform.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RetailPlatform.Common.Interfaces.Service
{
    public interface IAddService
    {
        IEnumerable<Add> FetchActiveAdds();
        Task RemoveAdd(long id);
    }
}
