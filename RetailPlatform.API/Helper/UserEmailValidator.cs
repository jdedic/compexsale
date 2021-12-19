using RetailPlatform.API.Models.DTO;
using RetailPlatform.Common.Interfaces.Repository;
using System.ComponentModel.DataAnnotations;

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
            
            var id = validationContext.ObjectType.Name == "UserDTO" ? ((UserDTO)validationContext.ObjectInstance).Id : ((EditUserDTO)validationContext.ObjectInstance).Id;
            return repositoryWrapper.User.CheckIfEmailAlreadyExist(id, value.ToString()) ? errorMessage : ValidationResult.Success;
        }
    }
}