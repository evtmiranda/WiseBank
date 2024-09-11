using WiseBank.Src.Repositories;
using WiseBank.Src.Services.Interfaces;

namespace WiseBank.Src.Services;

public static class ConfigureServices
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IWiseBankContext, WiseBankContext>();
        services.AddScoped<IBankAccountService, BankAccountService>();

        return services;
    }
}