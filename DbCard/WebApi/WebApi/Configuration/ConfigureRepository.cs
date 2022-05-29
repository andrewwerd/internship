using WebApi.Services;
using WebApi.Services.Implementations;

namespace WebApi.Configuration
{
    public static class ConfigureRepository
    {
        public static IServiceCollection AddAppRepository(this IServiceCollection services) =>
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    }
}
