using Mint.WebApp.Admin.Identity.Repositories;
using Mint.WebApp.Admin.Identity.Repositories.Interfaces;
using Mint.WebApp.Admin.Identity.Utils;

namespace Mint.WebApp.Admin.Identity;

public static class ConfigureAdminServices
{
    public static IServiceCollection AdminServicesCollection(this IServiceCollection services)
    {
        // Mapper
        services.AddAutoMapper(typeof(AdminMapper));

        // Repositories
        services.AddScoped<IAdminRepository, AdminRepository>();

        return services;
    }
}
