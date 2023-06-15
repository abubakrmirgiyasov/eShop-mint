namespace Mint.Infrastructure.Services.Interfaces;

public interface IScheduleConfig<T>
{
    string CronExpression { get; set; }

    TimeZoneInfo TimeZone { get; set; }
}
