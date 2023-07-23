using Mint.Infrastructure.MessageBrokers.Models;

namespace Mint.Infrastructure.MessageBrokers.Interfaces;

public interface IMessageSender<T>
{
    Task SendAsync(T message, MetaData? metaData = null, string? routingKey = null, CancellationToken cancellationToken = default);
}
