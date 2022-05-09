using DbCard.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DbCard.Configuration
{
    public static class ConfigureRepository
    {
        public static IServiceCollection AddAppRepository(this IServiceCollection services) =>
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    }
}
