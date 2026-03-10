using ACES_Project2.ACES_Corebusiness.Users;

namespace ACES_Project2.ACES_UseCases.Users.Repositories
{
    public interface IUserRepository 
    {
        Task<List<ManageUsers>> GetUsersAsync();
    }
}
