using Mint.Domain.Common;
using Mint.Infrastructure.Redis;
using Mint.Infrastructure.Redis.Interface;
using Mint.WebApp.Admin.Application;
using Mint.WebApp.Extensions.Identities;
using Mint.WebApp.Extensions.Infrastructures;
using Mint.WebApp.Extensions.Mappers;

namespace Mint.WebApp.Admin;

public static class ConfigureAdminServices
{
    public static IServiceCollection AdminServicesCollection(this IServiceCollection services, AppSettings? appSettings)
    {
        // Mapper
        services.AddUserAutoMapper();

        // Minio
        services.AddMinioServices();

        // Application
        services.ConfigureAdminApplication();

        services.AddScoped<IDistributedCacheManager, RedisCacheManager>();

        services.AddAuthenticationServices();

        // Utils
        services.AddJwtConfiguration(appSettings);

        // Message brokers
        //services.AddMessageBusSender<CategoryPhoto>(appSettings.MessageBroker);

        return services;
    }
}
