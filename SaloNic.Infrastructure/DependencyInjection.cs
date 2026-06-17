using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SaloNic.Application.Common.Interfaces;
using SaloNic.Infrastructure.Persistence;

namespace SaloNic.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddSingleton<IConnectionStringProvider>(
            new ConnectionStringProvider(configuration.GetConnectionString("DefaultConnection") ?? string.Empty));

        return services;
    }
}
