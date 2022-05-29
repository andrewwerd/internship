using Microsoft.AspNetCore.Mvc.Authorization;

namespace WebApi.Configuration
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
