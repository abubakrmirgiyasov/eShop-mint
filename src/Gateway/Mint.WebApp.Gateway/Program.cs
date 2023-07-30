using Mint.WebApp;
using Mint.WebApp.Services;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Configuration.File;
using Mint.Domain.Common;
using Mint.Infrastructure.MessageBrokers;
using Mint.Domain.Models.Identity;
using Mint.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Mint.Infrastructure.Services;
using Mint.Infrastructure.Services.Interfaces;
using Mint.Infrastructure.Repositories.Identity.Interfaces;
using Mint.Infrastructure.Repositories.Identity;

var builder = WebApplication.CreateBuilder(args);

var identitySettings = builder.Configuration.GetSection("IdentitySettings");
builder.Services.Configure<IdentitySettings>(identitySettings);

var config = builder.Configuration.GetSection("Ocelot");
var appSettings = config.Get<AppSettings>();
builder.Services.AddOcelot().AddDelegatingHandler<DebuggingHandler>(true);

var brokerSettings = builder.Configuration.GetSection("MessageBroker");
var brokerOptions = brokerSettings.Get<MessageBrokerOptions>();
builder.Services.AddMessageBusSender<User>(brokerOptions);

var redisSettings = builder.Configuration.GetSection("RedisSettings");
builder.Services.Configure<RedisSettings>(redisSettings);

var connection = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));

builder.Services.AddScoped<IJwt, Jwt>();
builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.PostConfigure<FileConfiguration>(configuration =>
{
    foreach (var route in appSettings!.Routes.Select(x => x.Value))
    {
        var uri = new Uri(route.Downstream);

        foreach (var pathTemplate in route.UpstreamPathTemplates)
        {
            configuration.Routes.Add(new FileRoute()
            {
                UpstreamPathTemplate = pathTemplate,
                DownstreamPathTemplate = pathTemplate,
                DownstreamScheme = uri.Scheme,
                DownstreamHostAndPorts = new List<FileHostAndPort>()
                {
                    new FileHostAndPort()
                    {
                        Host = uri.Host,
                        Port = uri.Port
                    },
                }
            });
        }
    }

    foreach (var route in configuration.Routes)
    {
        if (string.IsNullOrWhiteSpace(route.UpstreamPathTemplate))
            route.DownstreamScheme = builder.Configuration["Ocelot:DefaultDownstreamScheme"];

        if (string.IsNullOrWhiteSpace(route.DownstreamPathTemplate))
            route.DownstreamPathTemplate = route.UpstreamPathTemplate;
    }
});

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<JwtMiddleware>();

app.UseWebSockets();
app.UseOcelot().Wait();

app.Run();
