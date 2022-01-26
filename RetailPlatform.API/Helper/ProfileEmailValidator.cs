using RetailPlatform.Common.Interfaces.Repository;
using System.ComponentModel.DataAnnotations;

namespace RetailPlatform.API.Helper
{
    public class ProfileEmailValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var repositoryWrapper = (IRepositoryWrapper)validationContext.GetService(typeof(IRepositoryWrapper));
            var errorMessage = new ValidationResult($"Email već postoji");

            if (value == null)
            {
                return null;
            }

            return repositoryWrapper.Profile.CheckIfEmailAlreadyExist(value.ToString()) ? errorMessage : ValidationResult.Success;
        }
    }
}
