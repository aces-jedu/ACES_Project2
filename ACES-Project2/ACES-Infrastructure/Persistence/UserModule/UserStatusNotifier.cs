using ACES_Project2.ACES_UseCases.Users.Services;
using ACES_Project2.Components.Hub;
using Microsoft.AspNetCore.SignalR;

namespace ACES_Project2.ACES_Infrastructure.Persistence.UserModule
{
    public class UserStatusNotifier : IUserStatusNotifier
    {
        private readonly IHubContext<UserHub> hubContext;

        public UserStatusNotifier(IHubContext<UserHub> hubContext)
        {
            this.hubContext = hubContext;
        }

        public async Task NotifyUsersUpdated()
        {
            await hubContext.Clients.All.SendAsync("UsersUpdated");
        }
    }
}
