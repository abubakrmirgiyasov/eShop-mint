namespace Mint.WebApp.Ordering.Infrastructure.Interfaces;

public interface IUnitOfWork
{
    Task<bool> Commit();
}
