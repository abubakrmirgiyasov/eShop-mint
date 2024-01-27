using Mint.WebApp.Admin.Utils;

namespace Mint.WebApp.Admin;

public static class ConfigureAdminServices
{
    public static IServiceCollection AdminServicesCollection(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AdminMapper));

        return services;
    }
}
