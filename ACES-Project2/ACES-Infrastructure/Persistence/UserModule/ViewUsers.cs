using ACES_Project2.ACES_Corebusiness.Users;
using ACES_Project2.ACES_UseCases.Users.Repositories;
using ACES_Project2.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ACES_Project2.ACES_Infrastructure.Persistence.UserModule
{
    public class ViewUsers : IUserRepository
    {
        private readonly UserManager<ApplicationUser> userManager;

        public ViewUsers(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<List<ManageUsers>> GetUsersAsync()
        {
            var users = await userManager.Users.ToListAsync();

            return users.Select(u => new ManageUsers
            {
                Id = u.Id,
                Email = u.Email,
                UserName = u.UserName,
                IsActive = u.IsActive
            }).ToList();
        }
    }
}