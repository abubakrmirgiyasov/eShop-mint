using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Mint.Domain.Common;
using Mint.Infrastructure;
using Mint.Infrastructure.MessageBrokers.RabbitMQ;
using Mint.WebApp.Extensions.Infrastructures;
using Mint.WebApp.HealthChecker;
using Mint.WebApp.StorageCloud;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration.GetSection(nameof(AppSettings));
builder.Services.Configure<AppSettings>(config);

builder.Services.AddMinioServices();

var rabbitMQConf = config.GetSection("RabbitMQ");
var rabbitMqHostOpt = rabbitMQConf.Get<RabbitMQHealthCheckOptions>()!;

builder.Services.AddHealthChecks()
    .AddSqlServer(builder.Configuration.GetConnectionString("Default")!)
    .AddServicesHealthCheck("Gateway", "https://localhost:7064/health")
    .AddServicesHealthCheck("Admin Identity", "https://localhost:7007/health")
    .AddServicesHealthCheck("Admin App", "https://localhost:7135/health")
    .AddMinio("MINIO Service", "hlz")
    .AddRabbitMQ(new RabbitMQHealthCheckOptions() 
    {
        HostName = rabbitMqHostOpt.HostName,
        Password = rabbitMqHostOpt.Password,
        UserName = rabbitMqHostOpt.UserName,
    }, "RabbitMQ");

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
