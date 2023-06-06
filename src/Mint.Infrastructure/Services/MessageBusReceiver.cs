using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Mint.Domain.Models.Base;
using Mint.Domain.Models.Base.Interfaces;
using Mint.Infrastructure.MessageBrokers.Interfaces;

namespace Mint.Infrastructure.Services;

public class MessageBusReceiver : BackgroundService
{
    private readonly ILogger<MessageBusReceiver> _logger;
    private readonly IServiceProvider _service;
    private readonly IMessageReceiver<AuditLogEntry> _auditMessageReceiver;

    public MessageBusReceiver(
        ILogger<MessageBusReceiver> logger, 
        IMessageReceiver<AuditLogEntry> auditMessageReceiver,
        IServiceProvider service)
    {
        _logger = logger;
        _auditMessageReceiver = auditMessageReceiver;
        _service=service;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _auditMessageReceiver.ReceiveAsync(async (data, metaData) =>
        {
            using var scope = _service.CreateScope();
            var dispatcher = scope.ServiceProvider.GetRequiredService<Dispatcher>();
            data.Id = Guid.Empty;

            await dispatcher.DispatchAsync(new AddOrUpdateEntityCommand<AuditLogEntry>(data));

            _logger.LogInformation(data.Action);

            await Task.Delay(5000);
        }, stoppingToken);

        return Task.CompletedTask;
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