using HealthChecks.UI.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Mint.Infrastructure.HealthChekcs;

public static class HealthChecksUIBuilderExtensions
{
    public static HealthChecksUIBuilder AddInMemoryStorage(
        this HealthChecksUIBuilder builder,
        Action<DbContextOptionsBuilder>? configureOptions = null,
        string databaseName = "HealthChecksUI")
    {
        builder.Services.AddDbContext<HealthChecksDb>(options =>
        {
            configureOptions?.Invoke(options);
            options.UseInMemoryDatabase(databaseName);
        });
        
        return builder;
    }
}
