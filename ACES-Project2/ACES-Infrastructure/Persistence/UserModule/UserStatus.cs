using ACES_Project2.Data;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ACES_Project2.ACES_Infrastructure.Persistence.UserModule
{
    public class UserStatus
    {
        private readonly UserManager<ApplicationUser> UserModule;

        public UserStatus(UserManager<ApplicationUser> userManager)
        {
            UserModule = userManager;
        }

        // Set Active (1)
        public async Task SetUserActiveAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return;

            var user = await UserModule.FindByEmailAsync(email);

            if (user is null)
                return;

            // Check if LoginAt needs to be updated (only once per day)
            if (user.IsActive != 1 || !user.LoginAt.HasValue || user.LoginAt.Value.Date != DateTime.Now.Date)
            {
                user.IsActive = 1;

                // Only update LoginAt if it's null OR the last login was not today
                if (!user.LoginAt.HasValue || user.LoginAt.Value.Date != DateTime.Now.Date)
                {
                    user.LoginAt = DateTime.Now;
                }

                await UserModule.UpdateAsync(user);
            }
            else
            {
                // This case only executes when:
                // user.IsActive == 1 AND user.LoginAt.HasValue == true AND user.LoginAt.Value.Date == DateTime.Now.Date
                user.IsActive = 1;
                // Don't update LoginAt since it's already today
                await UserModule.UpdateAsync(user);
            }
        }

        // Set Inactive (0)
        public async Task SetUserInactiveAsync(ClaimsPrincipal principal)
        {
            var user = await UserModule.GetUserAsync(principal);

            if (user is null)
                return;

            if (user.IsActive != 0)
            {
                user.IsActive = 0;
                user.LogoutAt = DateTime.Now;
                await UserModule.UpdateAsync(user);
            }
        }
    }
}
