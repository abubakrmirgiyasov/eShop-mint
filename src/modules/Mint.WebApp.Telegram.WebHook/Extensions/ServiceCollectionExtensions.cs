using Mint.WebApp.Telegram.WebHook.Services;

namespace Mint.WebApp.Telegram.WebHook.Extensions;

public static class ServiceCollectionExtensions
{
    public delegate void ConfigureCommand(IServiceProvider serviceProvider, CommandManagerBuilder builder);

    public static IServiceCollection AddCommandManager(this IServiceCollection services, ConfigureCommand command)
    {
        services.AddScoped(service =>
        {
            var scope = service
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();

            var builder = new CommandManagerBuilder(scope);
            command(scope.ServiceProvider, builder);

            return builder.Build();
        });

        return services;
    }
}
