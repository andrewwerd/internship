using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace DbCard.Configuration
{
    public static class ConfigureControllers
    {
        public static IServiceCollection AddAppControllers(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add(new AuthorizeFilter());
            });

           return services;
        }
    }
}
