using Microsoft.Extensions.DependencyInjection;
using Mint.Infrastructure.Repositories.Identity;
using Mint.Infrastructure.Repositories.Identity.Interfaces;
using Mint.Infrastructure.Services;
using Mint.Infrastructure.Services.Interfaces;

namespace Mint.WebApp.Extensions.Identities;

public static class IdentityExtensions
{
    public static IServiceCollection AddAuthenticationServices(this IServiceCollection services)
    {
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
