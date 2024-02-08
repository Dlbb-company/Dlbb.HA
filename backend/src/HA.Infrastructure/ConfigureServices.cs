using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HA.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services;
    }
}