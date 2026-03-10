using ACES_Project2.ACES_Corebusiness.Users;
using ACES_Project2.ACES_UseCases.Users.Interfaces;
using ACES_Project2.ACES_UseCases.Users.Repositories;

namespace ACES_Project2.ACES_UseCases.Users
{
    public class ViewUsersUseCase : IViewUsersUseCase
    {
        private readonly IUserRepository ViewUsers;

        public ViewUsersUseCase(IUserRepository viewUsers)
        {
            this.ViewUsers = viewUsers;
        }

        public async Task<List<ManageUsers>> ExecuteAsync()
        {
            return await ViewUsers.GetUsersAsync();
        }
    }
}
