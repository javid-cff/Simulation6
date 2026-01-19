using Microsoft.AspNetCore.Identity;

namespace DigiMediaMVC.Models
{
    public class AppUser : IdentityUser
    {
        public string Fullname { get; set; } = string.Empty;
    }
}
