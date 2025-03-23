using Microsoft.AspNetCore.Identity;

namespace LibraryManagementSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }  // Kullanıcının Adı
        public string LastName { get; set; }   // Kullanıcının Soyadı
        public string ProfileImage { get; set; } // Profil Resmi Yolu
    }
}
