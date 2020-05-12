using DbCard.Context;
using DbCard.Domain.Auth;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Infrastructure
{
    public class Seed
    {
        public static async Task SeedCustomers(DbCardContext context)
        {
            if (!context.Customers.Any())
            {
               await context.SaveChangesAsync();
            }
        }

        public static async Task SeedPartners(DbCardContext context)
        {
            if (!context.Partners.Any())
            {
                await context.SaveChangesAsync();
            }
        }

        public static async Task SeedUsers(UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new User()
                {
                    UserName = "admin",
                    Email = "admin@dbcard.com",
                };
                await userManager.CreateAsync(user, "Qwerty12345");
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }

        public static async Task SeedRoles(RoleManager<Role> roleManager)
        {
            if(!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new Role() { Name = "Admin" });
                await roleManager.CreateAsync(new Role() { Name = "Customer"});
                await roleManager.CreateAsync(new Role() { Name = "Partner"});
            }
        }
    }
}

