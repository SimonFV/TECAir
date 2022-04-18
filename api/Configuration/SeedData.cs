using api.Entities;
using Microsoft.AspNetCore.Identity;

namespace api.Configuration
{
    public static class SeedData
    {
        public static void Seed(UserManager<User> userManager,
                                RoleManager<Role> roleManager)
        {
            SeedRoles(roleManager);
        }

        private static void SeedRoles(RoleManager<Role> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Employee").Result)
            {
                var role = new Role
                {
                    Name = "Employee"
                };
                roleManager.CreateAsync(role);
            }
            if (!roleManager.RoleExistsAsync("Client").Result)
            {
                var role = new Role
                {
                    Name = "Client"
                };
                var result = roleManager.CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync("Student").Result)
            {
                var role = new Role
                {
                    Name = "Student"
                };
                var result = roleManager.CreateAsync(role).Result;
            }
        }
    }
}