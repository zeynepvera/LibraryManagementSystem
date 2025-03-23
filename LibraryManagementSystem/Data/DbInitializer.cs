using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Data
{
    public class DbInitializer
    {
        public static async Task InitializeAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            try
            {
                //  Varsayılan roller
                var roles = new List<string> { "Admin", "User", "Librarian" }; // Yeni roller eklenebilir

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }

                //  Admin Kullanıcı Bilgileri
                string adminEmail = "admin@library.com";
                string adminPassword = "Admin123!";

                //  Eğer admin kullanıcı yoksa oluştur ve Admin rolüne ata
                if (await userManager.FindByEmailAsync(adminEmail) == null)
                {
                    var adminUser = new IdentityUser
                    {
                        UserName = adminEmail,
                        Email = adminEmail,
                        EmailConfirmed = true
                    };

                    var result = await userManager.CreateAsync(adminUser, adminPassword);

                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(adminUser, "Admin");
                    }
                    else
                    {
                        Console.WriteLine(" Admin kullanıcı oluşturulamadı! Hata: " + string.Join(", ", result.Errors));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Veritabanı başlatma sırasında hata oluştu: " + ex.Message);
            }
        }
    }
}
