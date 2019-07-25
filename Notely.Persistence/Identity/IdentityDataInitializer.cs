using Microsoft.AspNetCore.Identity;
using NotelyCore.Domain.Identity;

namespace Notely.Persistence.Identity
{
    public class IdentityDataInitializer
    {
        public static void SeedData(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("NormalUser").Result)
            {
                var role = new IdentityRole();
                role.Name = "NormalUser";
                roleManager.CreateAsync(role).Wait();
            }

            if (!roleManager.RoleExistsAsync("AdminUser").Result)
            {
                var role = new IdentityRole();
                role.Name = "AdminUser";
                roleManager.CreateAsync(role).Wait();
            }
        }

        private static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByNameAsync("devuser1").Result == null)
            {
                var user = new ApplicationUser();
                user.UserName = "devuser1";
                user.Email = "devuser1@localhost";

                IdentityResult result = userManager.CreateAsync(user, "Testuser1_").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "NormalUser").Wait();
                }
            }


            if (userManager.FindByNameAsync("devuser2").Result == null)
            {
                var user = new ApplicationUser();
                user.UserName = "devuser2";
                user.Email = "devuser2@localhost";

                IdentityResult result = userManager.CreateAsync(user, "Testuser2_").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "AdminUser").Wait();
                }
            }
        }
    }
}
