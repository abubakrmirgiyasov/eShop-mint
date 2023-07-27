using Ocelot.Configuration.File;

namespace Mint.WebApp.Extensions;

public static class ServiceCollectionBuilderExtension
{
    public static IServiceCollection PostFileConfigure(this IServiceCollection services, AppSettings settings, WebApplicationBuilder builder)
    {
        services.PostConfigure<FileConfiguration>(configuration =>
        {
            foreach (var route in settings!.Routes.Select(x => x.Value))
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

        return services;
    }
}
