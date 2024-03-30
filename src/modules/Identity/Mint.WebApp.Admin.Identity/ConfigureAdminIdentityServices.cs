using Mint.WebApp.Admin.Identity.Repositories;
using Mint.WebApp.Admin.Identity.Repositories.Interfaces;
using Mint.WebApp.Admin.Identity.Utils;
using Mint.WebApp.Extensions.Identities;
using Mint.WebApp.Extensions.Infrastructures;
using Mint.WebApp.Extensions.Mappers;

namespace Mint.WebApp.Admin.Identity;

public static class ConfigureAdminIdentityServices
{
    public static IServiceCollection AdminIdentityServicesCollection(this IServiceCollection services)
    {
        // Mapper
        services.AddAutoMapper(typeof(AdminIdentityMapper));
        services.AddUserAutoMapper();

        // Repositories
        services.AddScoped<IAdminRepository, AdminRepository>();

        // Services
        services.AddAuthenticationServices();
        services.AddMinioServices();

        return services;
    }
}
