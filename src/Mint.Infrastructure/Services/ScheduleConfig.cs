using Mint.Infrastructure.Services.Interfaces;

namespace Mint.Infrastructure.Services;

public class ScheduleConfig<T> : IScheduleConfig<T>
{
    public string CronExpression { get; set; } = null!;

    public TimeZoneInfo TimeZone { get; set; } = null!;
}
