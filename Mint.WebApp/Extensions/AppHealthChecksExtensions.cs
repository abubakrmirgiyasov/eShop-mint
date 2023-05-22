using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace Mint.WebApp.Extensions;

public static class AppHealthChecksExtensions
{
    public static IEndpointRouteBuilder HealthChecksRoutes(this IEndpointRouteBuilder app)
    {
        app.MapHealthChecks("/health/custom", new HealthCheckOptions()
        {
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
        }).RequireAuthorization();

        app.MapHealthChecks("/health", new HealthCheckOptions()
        {
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
        });

        return app;
    }
}
