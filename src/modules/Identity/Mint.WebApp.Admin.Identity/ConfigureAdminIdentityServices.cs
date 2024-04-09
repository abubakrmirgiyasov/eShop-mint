using Mint.Domain.Common;
using Mint.Infrastructure;
using Mint.WebApp.Identity.Application;

namespace Mint.WebApp.Admin.Identity;

public static class ConfigureAdminIdentityServices
{
    public static IServiceCollection AdminIdentityServicesCollection(this IServiceCollection services, AppSettings? appSettings)
    {
        // Services
        services
            .ConfigureIdentityApplication()
            .AddInfrastructureServices()
            .AddAdminIdentityRepositories()
            .AddAuthenticationServices()
            .AddJwtConfiguration(appSettings);

        return services;
    }
}
