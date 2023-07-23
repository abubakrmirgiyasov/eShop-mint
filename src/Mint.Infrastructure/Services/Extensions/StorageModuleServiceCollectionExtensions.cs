using Microsoft.Extensions.DependencyInjection;
using Mint.Domain.Models;
using Mint.Infrastructure.MessageBrokers;

namespace Mint.Infrastructure.Services.Extensions;

public static class StorageModuleServiceCollectionExtensions
{
    public static IServiceCollection AddStorageModule(this IServiceCollection services, MessageBrokerOptions settings)
    {
        services.AddMessageBusSender<Order>(settings);

        return services;
    }
}
