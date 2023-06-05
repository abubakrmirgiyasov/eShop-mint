using Microsoft.Extensions.DependencyInjection;
using Mint.Domain.Models;
using Mint.Infrastructure.MessageBrokers;
using Mint.Infrastructure.MessageBrokers.Test;

namespace Mint.Infrastructure.Services;

public static class StorageModuleServiceCollectionExtensions
{
    public static IServiceCollection AddStorageModule(this IServiceCollection services, MessageBrokerOptions settings)
    {
        services
            .AddMessageBusSender<AuditLogEntryTest>(settings)
            ; // .AddMessageBusReceiver<AuditLogEntryTest>(settings)

        return services;
    }

    public static IServiceCollection AddHostServiceStorageModule(this IServiceCollection services)
    {
        //services.AddHostedService<MessageBusReceiver>();

        return services;
    }
}
