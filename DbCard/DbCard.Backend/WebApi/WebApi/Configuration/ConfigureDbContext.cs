using Context;

namespace WebApi.Configuration
{
    public static class ConfigureDbContext
    {
        public static IServiceCollection AddAppDbContext(this IServiceCollection services)
        {
            DbCardContextSettings.Create();
            return services.AddDbContext<DbCardContext>();
        }
    }
}
