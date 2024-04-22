using Mint.Domain.Common;
using Mint.Infrastructure;
using Mint.WebApp.Admin.Application;
using Mint.WebApp.Admin.Helpers;

namespace Mint.WebApp.Admin;

public static class ConfigureAdminServices
{
    public static IServiceCollection AdminServicesCollection(this IServiceCollection services, AppSettings? appSettings)
    {
        services
            .AddProblemDetails()
            .AddExceptionHandler<ExceptionToProblemDetailsHandler>();

        services
            .AddAdminApplicationServices()
            .AddInfrastructureServices()
            .AddAdminRepositories()
            .AddAuthenticationServices()
            .AddJwtConfiguration(appSettings);

        return services;
    }
}
