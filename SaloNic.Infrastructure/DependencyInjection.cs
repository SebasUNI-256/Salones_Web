using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SaloNic.Application.Common.Interfaces;
using SaloNic.Infrastructure.DataBase;
using SaloNic.Infrastructure.Persistence;
using SaloNic.Infrastructure.Repository;

namespace SaloNic.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection") ?? string.Empty;

        services.AddSingleton<IConnectionStringProvider>(new ConnectionStringProvider(connectionString));
        services.AddSingleton(new DBConnectionFactory(connectionString));

        services.AddScoped<IBitacoraRepository, BitacoraRepository>();
        services.AddScoped<ICancelacionRepository, CancelacionRepository>();
        services.AddScoped<IClienteRepository, ClienteRepository>();

        return services;
    }
}
