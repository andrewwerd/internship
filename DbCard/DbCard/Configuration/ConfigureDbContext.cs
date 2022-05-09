using DbCard.Context;
using Microsoft.Extensions.DependencyInjection;

namespace DbCard.Configuration
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
