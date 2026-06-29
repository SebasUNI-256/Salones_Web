using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SaloNic.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        foreach (var serviceType in Assembly.GetExecutingAssembly()
                     .GetTypes()
                     .Where(t => t.IsClass && !t.IsAbstract && t.Namespace == "SaloNic.Application.Common.Services"))
        {
            services.AddScoped(serviceType);
        }

        return services;
    }
}
