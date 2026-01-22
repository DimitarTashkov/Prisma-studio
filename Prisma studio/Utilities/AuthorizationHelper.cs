using HotelOazis.Services;
using Prisma_studio.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prisma_studio.Utilities
{
    public class AuthorizationHelper
    {
        private static bool isAuthorized;
        public static async Task<bool> InitializeAuthorizationStatusAsync(IUserService userService)
        {
            bool _isAuthorized;
            var loggedInUser = userService.GetLoggedInUserAsync();
            if (loggedInUser != null)
            {
                _isAuthorized = await userService.IsUserAdminAsync(loggedInUser.Id);
            }
            else
            {
                _isAuthorized = false;
            }
            isAuthorized = _isAuthorized;
            return _isAuthorized;
        }
        public static bool IsAuthorized()
        {
            return isAuthorized;
        }
    }
    
}
