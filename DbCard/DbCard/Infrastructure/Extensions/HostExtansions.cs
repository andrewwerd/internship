using DbCard.Context;
using DbCard.Domain.Auth;
using DbCard.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DbCard.Infrastructure.Extensions
{
    public static class HostExtensions
    {
        public static async Task SeedData(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<DbCardContext>();
                    var userManager = services.GetRequiredService<UserManager<User>>();
                    var roleManager = services.GetRequiredService<RoleManager<Role>>();
                    var customerService = services.GetRequiredService<ICustomerService>();
                    context.Database.Migrate();

                    await Seed.SeedRoles(roleManager);
                    await Seed.SeedUsers(userManager,customerService);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
