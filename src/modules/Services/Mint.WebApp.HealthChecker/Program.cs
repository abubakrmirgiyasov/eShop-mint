using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Mint.Domain.Common;
using Mint.WebApp.Extensions.Infrastructures;
using Mint.WebApp.HealthChecker;
using Mint.WebApp.StorageCloud;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration.GetSection(nameof(AppSettings));
builder.Services.Configure<AppSettings>(config);

builder.Services.AddMinioServices();

builder.Services.AddHealthChecks()
    .AddSqlServer(builder.Configuration.GetConnectionString("Default")!)
    .AddServicesHealthCheck("Gateway", "https://localhost:7064/health")
    .AddServicesHealthCheck("Admin Identity", "https://localhost:7007/health")
    .AddServicesHealthCheck("Admin App", "https://localhost:7135/health")
    .AddMinio("MINIO Service", "first");

builder.Services.AddHealthChecksUI(options =>
{
    options.AddHealthCheckEndpoint("api", "healthz");
}).AddInMemoryStorage();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseHealthChecks("/healthz", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseHealthChecksUI(options =>
{
    options.UIPath = "/healthchecks-ui";
    options.ApiPath = "/healthchecks-api";
});

app.Run();
