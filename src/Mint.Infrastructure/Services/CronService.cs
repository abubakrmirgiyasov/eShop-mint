using Cronos;
using Microsoft.Extensions.Hosting;
using Timer = System.Timers.Timer;

namespace Mint.Infrastructure.Services;

public abstract class CronService : IHostedService, IDisposable
{
    private Timer _timer = null!;
    private readonly CronExpression _cronExpression;
    private readonly TimeZoneInfo _timeZone;

    public CronService(string cronExpression, TimeZoneInfo timeZoneInfo)
    {
        _cronExpression = CronExpression.Parse(cronExpression);
        _timeZone = timeZoneInfo;
    }

    public virtual async Task StartAsync(CancellationToken cancellationToken)
    {
        await ScheduleJob(cancellationToken);
    }

    public virtual async Task StopAsync(CancellationToken cancellationToken)
    {
        _timer.Stop();
        await Task.CompletedTask;
    }

    public virtual async Task ScheduleJob(CancellationToken cancellationToken)
    {
        var next = _cronExpression.GetNextOccurrence(DateTimeOffset.Now, _timeZone);

        if (!next.HasValue) return;

        var delay = next.Value - DateTimeOffset.Now;

        if (delay.TotalMicroseconds <= 0)
        {
            await ScheduleJob(cancellationToken);
            return;
        }

        _timer = new Timer(delay.TotalMicroseconds);
        _timer.Elapsed += async (s, e) =>
        {
            _timer.Dispose();
            _timer = null!;

            if (!cancellationToken.IsCancellationRequested) await DoWork(cancellationToken);
            if (!cancellationToken.IsCancellationRequested) await ScheduleJob(cancellationToken);
        };
        _timer.Start();
    }

    public virtual async Task DoWork(CancellationToken cancellationToken)
    {
        await Task.Delay(5000, cancellationToken);
    }

    public virtual void Dispose()
    {
        _timer.Dispose();
    }
}
