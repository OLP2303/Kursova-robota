using Microsoft.AspNetCore.Identity;

namespace BlazorApp2.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string User_name { get; set; } = " ";
        public DateTime Birth_date { get; set; }= DateTime.Today;
        public byte[]? UserPicture { get; set; }
    }

}
