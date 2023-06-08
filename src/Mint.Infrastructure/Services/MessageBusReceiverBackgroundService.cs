using Cronos;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Mint.Domain.Models.Base;
using Mint.Domain.Models.Base.Interfaces;
using Mint.Infrastructure.MessageBrokers.Interfaces;
using Mint.Infrastructure.Services.Interfaces;

namespace Mint.Infrastructure.Services;

public class MessageBusReceiverBackgroundService : CronService
{
    public MessageBusReceiverBackgroundService(IScheduleConfig<MessageBusReceiverBackgroundService> config) 
        : base(config.CronExpression, config.TimeZone) { }

    public override Task StartAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine($"[{DateTime.Now:hh:mm:ss}] Started...", ConsoleColor.Green);
        return base.StartAsync(cancellationToken);
    }

    public override Task DoWork(CancellationToken cancellationToken)
    {
        Console.WriteLine($"[{DateTime.Now:hh:mm:ss}] Working...", ConsoleColor.Blue);
        return base.DoWork(cancellationToken);
    }

    public override Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine($"[{DateTime.Now:hh:mm:ss}] Stopping...", ConsoleColor.Cyan);
        return base.StopAsync(cancellationToken);
    }
}

public class AddOrUpdateEntityCommand<TEntity> : ICommand
    where TEntity : Entity<Guid>, IAggregateRoot
{
    public AddOrUpdateEntityCommand(TEntity entity)
    {
        Entity = entity;
    }

    public TEntity Entity { get; set; }
}

internal class AddOrUpdateEntityCommandHandler<TEntity> : ICommandHandler<AddOrUpdateEntityCommand<TEntity>>
    where TEntity : Entity<Guid>, IAggregateRoot
{
    private readonly ICrudService<TEntity> _crud;

    public AddOrUpdateEntityCommandHandler(ICrudService<TEntity> crud)
    {
        _crud = crud;
    }

    public async Task HandleAsync(AddOrUpdateEntityCommand<TEntity> command, CancellationToken cancellationToken = default)
    {
        await _crud.AddOrUpdateAsync(command.Entity);
    }
}

public interface ICrudService<T>
    where T : Entity<Guid>, IAggregateRoot
{
    Task AddOrUpdateAsync(T entity, CancellationToken cancellationToken = default);
}
