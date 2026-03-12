using Microsoft.AspNetCore.Identity;

namespace ACES_Project2.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LoginAt { get; set; }
        public DateTime? LogoutAt { get; set; }
        public int IsActive { get; set; } = 0;
        public bool EmailConfirmed { get; set; }
    }

}
