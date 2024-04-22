using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Mint.Application;
using Mint.WebApp.Client.Application.Operations.Dtos.Categories;

namespace Mint.WebApp.Client.Application;

public static class ConfigureClientApplicationServices
{
    public static IServiceCollection AddClientApplicationService(this IServiceCollection services)
    {
        // mapper
        services.AddAutoMapper(typeof(Catalog));

        services.AddMediatR(opt => opt.RegisterServicesFromAssembly(typeof(ClientApplicationRef).Assembly));
        services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

        return services;
    }
}
