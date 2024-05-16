using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Mint.Application;
using Mint.WebApp.Admin.Identity.Application.Mapper;

namespace Mint.WebApp.Admin.Identity.Application;

public static class ConfigureAdminIdentityApplicationServices
{
    public static IServiceCollection AddAdminIdentityApplicationServices(this IServiceCollection services)
    {
        // mapper
        services.AddAutoMapper(typeof(ConsumerMapper));

        services.AddMediatR(opt => opt.RegisterServicesFromAssembly(typeof(AdminIdentityApplicationRef).Assembly));
        services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

        return services;
    }
}
