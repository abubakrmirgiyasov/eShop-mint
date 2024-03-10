using MediatR;
using Mint.Domain.Common;
using Mint.Infrastructure.MessageBrokers;
using Mint.Infrastructure.Redis;
using Mint.Infrastructure.Redis.Interface;
using Mint.Infrastructure.Repositories.Admin;
using Mint.Infrastructure.Repositories.Admin.Interfaces;
using Mint.WebApp.Admin.Repositories;
using Mint.WebApp.Admin.Repositories.Interfaces;
using Mint.WebApp.Admin.Services;
using Mint.WebApp.Admin.Utils;
using Mint.WebApp.Extensions.Infrastructures;
using Mint.WebApp.Extensions.Identities;
using Mint.WebApp.Extensions.Mappers;

namespace Mint.WebApp.Admin;

public static class ConfigureAdminServices
{
    public static IServiceCollection AdminServicesCollection(this IServiceCollection services, AppSettings? appSettings)
    {
        // Mapper
        services.AddAutoMapper(typeof(AdminMapper));
        services.AddUserAutoMapper();

        // Minio
        services.AddMinioServices();

        // Services
        services.AddScoped<CategoryService>();
        services.AddScoped<TagService>();
        services.AddScoped<RedisClient>();

        // Repositories
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ITagRepository, TagRepository>();
        services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
        services.AddScoped<IManufactureRepository, ManufactureRepository>();

        services.AddScoped<IDistributedCacheManager, RedisCacheManager>();

        services.AddAuthenticationServices();

        // Utils
        services.AddJwtConfiguration(appSettings);
        services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

        // Message brokers
        //services.AddMessageBusSender<CategoryPhoto>(appSettings.MessageBroker);

        return services;
    }
}
