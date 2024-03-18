using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Mint.Infrastructure.MessageBrokers;
using Mint.Infrastructure.Redis;
using Mint.Infrastructure.Repositories.Admin;
using Mint.Infrastructure.Services.Interfaces;
using Mint.WebApp.Admin.Application.Operations.Repositories;
using Mint.WebApp.Admin.Application.Operations.Services;
using Mint.WebApp.Admin.Services;

namespace Mint.WebApp.Admin.Application;

public static class ConfigureAdminApplicationServices
{
    public static IServiceCollection ConfigureAdminApplication(this IServiceCollection services)
    {
        services.AddMediatR(opt => opt.RegisterServicesFromAssembly(typeof(AdminApplicationRef).Assembly));

        services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

        // services
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ITagService, TagService>();
        services.AddScoped<RedisClient>();

        // Repositories
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ITagRepository, TagRepository>();
        services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
        services.AddScoped<IManufactureRepository, ManufactureRepository>();

        return services;
    }
}
