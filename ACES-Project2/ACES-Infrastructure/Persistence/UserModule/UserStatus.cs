using ACES_Project2.Data;
using ACES_Project2.ACES_UseCases.Users.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;

namespace ACES_Project2.ACES_Infrastructure.Persistence.UserModule
{
    public class UserStatus
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IUserStatusNotifier _notifier;

        public UserStatus(IServiceScopeFactory scopeFactory, IUserStatusNotifier notifier)
        {
            _scopeFactory = scopeFactory;
            _notifier = notifier;
        }

        /// <summary>
        /// Set user as active (1) by email.
        /// Automatically updates LoginAt if not today.
        /// Safe to call from SignalR callbacks.
        /// </summary>
        public async Task SetUserActiveAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return;

            using var scope = _scopeFactory.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var user = await userManager.FindByEmailAsync(email);
            if (user is null)
                return;

            bool shouldUpdateLoginAt =
                !user.LoginAt.HasValue ||
                user.LoginAt.Value.Date != DateTime.UtcNow.Date;

            if (user.IsActive != 1 || shouldUpdateLoginAt)
            {
                user.IsActive = 1;

                if (shouldUpdateLoginAt)
                {
                    user.LoginAt = DateTime.UtcNow;
                }

                await userManager.UpdateAsync(user);

                // Notify SignalR clients
                await _notifier.NotifyUsersUpdated();
            }
        }

        /// <summary>
        /// Set user as inactive (0) based on ClaimsPrincipal.
        /// Updates LogoutAt.
        /// Safe to call from SignalR callbacks.
        /// </summary>
        public async Task SetUserInactiveAsync(ClaimsPrincipal principal)
        {
            if (principal == null)
                return;

            using var scope = _scopeFactory.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var user = await userManager.GetUserAsync(principal);
            if (user is null)
                return;

            if (user.IsActive != 0)
            {
                user.IsActive = 0;
                user.LogoutAt = DateTime.UtcNow;

                await userManager.UpdateAsync(user);

                // Notify SignalR clients
                await _notifier.NotifyUsersUpdated();
            }
        }
    }
}