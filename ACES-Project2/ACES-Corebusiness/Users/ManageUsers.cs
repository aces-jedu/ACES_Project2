namespace ACES_Project2.ACES_Corebusiness.Users
{
    public class ManageUsers
    {
        public string Id { get; set; } = "";
        public string Email { get; set; } = "";
        public string UserName { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string MiddleName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Gender { get; set; } = "";
        public DateTime? DateOfBirth { get; set; }
        public int IsActive { get; set; }
        public string Role { get; set; } = "";
        public string RoleName { get; set; } = "";
    }
}
