using DbCard.Context;
using DbCard.Domain;
using DbCard.Domain.Auth;
using DbCard.Services;
using DbCard.Infrastructure.Extensions;
using DbCard.Services.Implementations;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Infrastructure
{
    public class Seed
    {

        public static async Task SeedPartners(DbCardContext context)
        {
            if (!context.Partners.Any())
            {
                await context.SaveChangesAsync();
            }
        }

        public static async Task SeedUsers(UserManager<User> userManager, ICustomerService customerService)
        {
            if (!userManager.Users.Any())
            {
                var user = new User()
                {
                    UserName = "john11",
                    Email = "john1@dbcard.com"
                };
                await userManager.CreateAsync(user, "Qwerty12345");
                await userManager.AddToRoleAsync(user, "Customer");
                var customer = new Customer()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Barcode = Guid.NewGuid().NewShortGuid()
                };
                await customerService.CreateAsync(customer, user);
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

