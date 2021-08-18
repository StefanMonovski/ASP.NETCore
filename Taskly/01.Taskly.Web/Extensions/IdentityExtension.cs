using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taskly.Data.Models;

namespace Taskly.Web.Extensions
{
    public static class IdentityExtension
    {
        public static async Task<string> GetSignInMethod(string emailOrUsername, UserManager<ApplicationUser> _userManager)
        {
            var signInMethod = emailOrUsername;
            if (emailOrUsername.Contains('@'))
            {
                var user = await _userManager.FindByEmailAsync(signInMethod);
                if (user != null)
                {
                    signInMethod = user.UserName;
                }
            }
            return signInMethod;
        }
    }
}
