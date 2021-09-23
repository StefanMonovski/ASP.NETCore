using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using Taskly.Data;
using Taskly.Data.Models;
using Taskly.Services.DataTransferObjects;
using Taskly.Services.Interfaces;

namespace Taskly.Services.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHttpContextAccessor httpContext;

        public UserService(ApplicationDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContext)
        {
            this.context = context;
            this.mapper = mapper;
            this.userManager = userManager;
            this.httpContext = httpContext;
        }

        public async Task<UserDto> GetCurrentUser()
        {
            ApplicationUser user = await userManager.GetUserAsync(httpContext.HttpContext.User);
            UserDto userDto = mapper.Map<UserDto>(user);

            return userDto;
        }

        public async Task<string> GetCurrentId()
        {
            ApplicationUser user = await userManager.GetUserAsync(httpContext.HttpContext.User);

            return user.Id;
        }

        public async Task<string> GetCurrentUsername()
        {
            ApplicationUser user = await userManager.GetUserAsync(httpContext.HttpContext.User);

            return user.UserName;
        }

        public async Task<string> GetCurrentEmail()
        {
            ApplicationUser user = await userManager.GetUserAsync(httpContext.HttpContext.User);

            return user.Email;
        }

        public bool DoesUserExistByUsername(string username)
        {
            UserDto user = context.Users
                .Where(x => x.UserName == username)
                .ProjectTo<UserDto>(mapper.ConfigurationProvider)
                .FirstOrDefault();

            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool DoesUserExistByEmail(string email)
        {
            UserDto user = context.Users
                .Where(x => x.Email == email)
                .ProjectTo<UserDto>(mapper.ConfigurationProvider)
                .FirstOrDefault();

            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public UserDto GetUserById(string id)
        {
            UserDto user = context.Users
                .Where(x => x.Id == id)
                .ProjectTo<UserDto>(mapper.ConfigurationProvider)
                .FirstOrDefault();

            return user;
        }

        public UserDto GetUserByUsername(string username)
        {
            UserDto user = context.Users
                .Where(x => x.UserName == username)
                .ProjectTo<UserDto>(mapper.ConfigurationProvider)
                .FirstOrDefault();

            return user;
        }

        public UserDto GetUserByEmail(string email)
        {
            UserDto user = context.Users
                .Where(x => x.Email == email)
                .ProjectTo<UserDto>(mapper.ConfigurationProvider)
                .FirstOrDefault();

            return user;
        }
    }
}
