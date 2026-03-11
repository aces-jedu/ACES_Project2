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

            var result = new List<ManageUsers>();

            foreach (var user in users)
            {
                var roles = await userManager.GetRolesAsync(user);

                result.Add(new ManageUsers
                {
                    Id = user.Id,
                    Email = user.Email,
                    UserName = user.UserName,
                    IsActive = user.IsActive,
                    FirstName = user.FirstName,
                    MiddleName = user.MiddleName,
                    LastName = user.LastName,
                    Gender = user.Gender,
                    DateOfBirth = user.DateOfBirth,
                    RoleName = roles.FirstOrDefault() ?? "No Role"
                });
            }

            return result;
        }
    }
}