using Mint.WebApp.Client.Application;
using Mint.Infrastructure;
using Mint.Domain.Common;

namespace Mint.WebApp.Client;

public static class ConfigureClientServices
{
    public static IServiceCollection ClientServicesCollection(this IServiceCollection services, AppSettings? appSettings)
    {
        services
            .AddProblemDetails();
            // .AddExceptionHandler<>;

        services
            .AddClientApplicationService()
            .AddInfrastructureServices()
            .AddClientRepositories()
            .AddAuthenticationServices()
            .AddJwtConfiguration(appSettings);

        return services;
    }
}
