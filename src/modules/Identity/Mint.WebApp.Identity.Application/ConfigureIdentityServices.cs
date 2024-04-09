using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Mint.Application;
using Mint.WebApp.Identity.Application.Mapper;

namespace Mint.WebApp.Identity.Application;

public static class ConfigureIdentityServices
{
    public static IServiceCollection ConfigureIdentityApplication(this IServiceCollection services)
    {
        // mapper
        services.AddAutoMapper(typeof(AdminIdentityMapper));
        services.AddAutoMapper(typeof(UserMapper));

        services.AddMediatR(opt => opt.RegisterServicesFromAssembly(typeof(IdentityApplicationRef).Assembly));
        services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

        return services;
    }
}
