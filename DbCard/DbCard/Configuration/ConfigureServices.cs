using DbCard.Services;
using Microsoft.Extensions.DependencyInjection;
using DbCard.Services.Implementations;

namespace DbCard.Configuration
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services) =>
            services.AddScoped<IFilialService, FilialService>()
                .AddScoped<ICustomerService, CustomerService>()
                .AddScoped<ICategoryService, CategoryService>()
                .AddScoped<IDiscountService, DiscountService>()
                .AddScoped<ITransactionService, TransactionsService>()
                .AddScoped<IPartnerService, PartnerService>()
                .AddScoped<IAccountService, AccountService>()
                .AddScoped<IBalanceService, BalanceService>();
    }
}
