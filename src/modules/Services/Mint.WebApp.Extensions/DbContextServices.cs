using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mint.Infrastructure;

namespace Mint.WebApp.Extensions;

public static class DbContextServices
{
    public static IServiceCollection AddDbContextServices(this IServiceCollection services, IConfiguration configuration, string connectionString)
    {
        var str = configuration.GetSection(connectionString);
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(str.Value));

        return services;
    }
}
