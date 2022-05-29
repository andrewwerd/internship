using Context;
using Domain.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApi.Services;

namespace WebApi.Infrastructure.Extensions
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
                    var partnerService = services.GetRequiredService<IPartnerService>();
                    var filialService = services.GetRequiredService<IFilialService>();
                    var transactionService = services.GetRequiredService<ITransactionService>();

                    context.Database.Migrate();

                    await Seed.SeedCategories(context);
                    await Seed.SeedRoles(roleManager);
                    await Seed.SeedPartners(userManager,context, partnerService);
                    await Seed.SeedCustomers(userManager,context, customerService, partnerService);
                    await Seed.SeedTransactions(context, transactionService, filialService, customerService);
                }
                catch (Exception)
                {
                    var context = services.GetRequiredService<DbCardContext>();
                    context.Database.EnsureDeleted();
                    throw;
                }
            }
        }
    }
}
