using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Mint.Application;
using Mint.WebApp.Admin.Application.Mapper;

namespace Mint.WebApp.Admin.Application;

public static class ConfigureAdminApplicationServices
{
    public static IServiceCollection AddAdminApplicationServices(this IServiceCollection services)
    {
        // mapper
        services.AddAutoMapper(typeof(AdminMapper));
        services.AddAutoMapper(typeof(ProductMapper));
        services.AddAutoMapper(typeof(StoreMapper));

        services.AddMediatR(opt => opt.RegisterServicesFromAssembly(typeof(AdminApplicationRef).Assembly));
        services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

        return services;
    }
}
