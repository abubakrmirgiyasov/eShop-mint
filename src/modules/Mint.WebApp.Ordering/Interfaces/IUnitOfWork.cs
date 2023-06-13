namespace Mint.WebApp.Ordering.Interfaces;

public interface IUnitOfWork
{
    Task<bool> Commit();
}
