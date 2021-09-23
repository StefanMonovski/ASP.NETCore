using System.Threading.Tasks;
using Taskly.Services.DataTransferObjects;

namespace Taskly.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetCurrentUser();

        Task<string> GetCurrentId();

        Task<string> GetCurrentUsername();

        Task<string> GetCurrentEmail();

        bool DoesUserExistByUsername(string username);

        bool DoesUserExistByEmail(string email);

        UserDto GetUserById(string id);

        UserDto GetUserByUsername(string username);

        UserDto GetUserByEmail(string email);
    }
}