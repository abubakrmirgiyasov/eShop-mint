using Mint.WebApp.Admin.Identity.Repositories;
using Mint.WebApp.Admin.Identity.Repositories.Interfaces;
using Mint.WebApp.Admin.Identity.Utils;

namespace Mint.WebApp.Admin.Identity;

public static class ConfigureAdminIdentityServices
{
    public static IServiceCollection AdminIdentityServicesCollection(this IServiceCollection services)
    {
        // Mapper
        services.AddAutoMapper(typeof(AdminIdentityMapper));

        // Repositories
        services.AddScoped<IAdminRepository, AdminRepository>();

        return services;
    }
}
