using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mint.Infrastructure;

namespace Mint.WebApp.Extensions;

public static class DbContextServices
{
    public static IServiceCollection AddDbContextServices(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

        return services;
    }
}
