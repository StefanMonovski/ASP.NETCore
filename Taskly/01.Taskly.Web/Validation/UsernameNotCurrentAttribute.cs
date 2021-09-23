using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Taskly.Services.Interfaces;

namespace Taskly.Web.Validation
{
    public class UsernameNotCurrentAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string username = (string)value;
            var usersService = (IUserService)validationContext.GetService(typeof(IUserService));

            string currentUsername = Task.Run(() => usersService.GetCurrentUsername()).GetAwaiter().GetResult();

            if (username == currentUsername)
            {
                return new ValidationResult("Cannot add own username.");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
