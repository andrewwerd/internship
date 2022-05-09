using DbCard.Context;
using DbCard.Domain.Auth;
using DbCard.Infrastructure.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace DbCard.Configuration
{
    public static class ConfigureAuthentication
    {
        public static IServiceCollection AddAppAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<User, Role>(options =>
                {
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequiredLength = 8;
                    options.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<DbCardContext>();

            var authOptions = services.ConfigureAuthOptions(configuration);
            services.AddJwtAuthentication(authOptions);

            return services;
        }
    }
}
