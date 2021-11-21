using System;
using System.Collections.Generic;
using System.Text;

namespace RetailPlatform.Common.Interfaces.Service
{
    public interface IUserService
    {
        bool CheckUserCredentials(string email, string password);
    }
}
