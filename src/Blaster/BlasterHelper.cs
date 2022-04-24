using Blaster.Abstracts;
using Blaster.Concretes;
using Blaster.Store;
using Microsoft.Extensions.DependencyInjection;

namespace Blaster;

public static class BlasterHelper
{
    public static IServiceCollection AddBlaster(this IServiceCollection services)
    {
        services.AddSingleton<IBlasterRepository, InMemoryRepository>();
        services.AddSingleton<IBlasterService, BlasterService>();

        return services;
    }
}