using Mint.Gateaway.Common;
using Mint.Gateway;
using Ocelot.Configuration.File;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration.GetSection("Ocelot");
var appSettings = config.Get<AppSettings>();

builder.Services
    .AddOcelot()
    .AddDelegatingHandler<DebuggingHandler>(true);

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

app.UseWebSockets();
app.UseOcelot().Wait();

app.MapGet("/", () => "Hello World!");

app.Run();
