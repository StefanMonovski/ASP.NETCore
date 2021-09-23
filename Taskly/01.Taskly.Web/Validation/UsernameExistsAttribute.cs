using System.ComponentModel.DataAnnotations;
using Taskly.Services.Interfaces;
using Taskly.Services.Services;

namespace Taskly.Web.Validation
{
    public class UsernameExistsAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string username = (string)value;
            var userService = (IUserService)validationContext.GetService(typeof(IUserService));

            bool result = userService.DoesUserExistByUsername(username);

            if (result == false)
            {
                return new ValidationResult($"Username {username} does not exist.");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}