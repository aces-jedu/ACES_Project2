using ACES_Project2.ACES_Corebusiness.Users;

namespace ACES_Project2.ACES_UseCases.Users.Interfaces
{
    public interface IViewUsersUseCase
    {
        Task<List<ManageUsers>> ExecuteAsync();
    }
}
