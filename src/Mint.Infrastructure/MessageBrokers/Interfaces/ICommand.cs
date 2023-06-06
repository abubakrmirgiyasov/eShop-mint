namespace Mint.Infrastructure.MessageBrokers.Interfaces;

public interface ICommand
{

}

public interface ICommandHandler<TCommand>
    where TCommand : ICommand
{
    Task HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}