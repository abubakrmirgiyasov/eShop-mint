using Microsoft.Extensions.DependencyInjection;
using Mint.Infrastructure.Services.Interfaces;

namespace Mint.Infrastructure.Services.Extensions;

public static class ScheduleConfigCollectionExtensions
{
    public static IServiceCollection AddCron<T>(this IServiceCollection services, Action<IScheduleConfig<T>> options)
        where T : CronService
    {
        if (options == null)
            throw new ArgumentNullException(nameof(options), "Please provide Schedule Configuration");

        var config = new ScheduleConfig<T>();
        options.Invoke(config);

        if (string.IsNullOrWhiteSpace(config.CronExpression))
            throw new ArgumentNullException(nameof(ScheduleConfig<T>.CronExpression), "Empty cron expression is not allowed");

        services.AddSingleton<IScheduleConfig<T>>(config);
        services.AddHostedService<T>();

        return services;
    }
}
