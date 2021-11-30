using RetailPlatform.API.Models.DTO;
using RetailPlatform.Common.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RetailPlatform.API.Helper
{
    public class UserEmailValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var repositoryWrapper = (IRepositoryWrapper)validationContext.GetService(typeof(IRepositoryWrapper));
            var errorMessage = new ValidationResult($"Email već postoji");
          
            if (value == null)
            {
                return null;
            }
            var id = ((UserDTO)validationContext.ObjectInstance).Id;
            return repositoryWrapper.User.CheckIfEmailAlreadyExist(id, value.ToString()) ? errorMessage : ValidationResult.Success;
        }
    }
}