using Microsoft.Extensions.DependencyInjection;
using Mint.Domain.Models;
using Mint.Domain.Models.Base;
using Mint.Infrastructure.MessageBrokers;

namespace Mint.Infrastructure.Services.Extensions;

public static class StorageModuleServiceCollectionExtensions
{
    public static IServiceCollection AddStorageModule(this IServiceCollection services, MessageBrokerOptions settings)
    {
        services
            .AddMessageBusSender<Order>(settings);

        return services;
    }

    public static IServiceCollection AddHostedServicesStorageModule(this IServiceCollection services)
    {
        services.AddHostedService<MessageBrokerBackgroundService>();

        return services;
    }
}
