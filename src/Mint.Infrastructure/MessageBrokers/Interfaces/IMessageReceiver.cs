using Mint.Infrastructure.MessageBrokers.Models;

namespace Mint.Infrastructure.MessageBrokers.Interfaces;

public interface IMessageReceiver<T>
{
    Task ReceiveAsync(Func<T, MetaData, Task> action, CancellationToken cancellationToken);
}
