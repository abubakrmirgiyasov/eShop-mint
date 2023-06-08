namespace Mint.Infrastructure.Services.Interfaces;

public interface IScopedService
{
    Task DoWork(CancellationToken cancellationToken);
}
