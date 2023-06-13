using Mint.WebApp.Ordering.Interfaces;
using Mint.WebApp.Ordering.Models;

namespace Mint.WebApp.Ordering.Infrastructure.Repositories;

public interface IOrderRepository : IRepository<Order, Guid>
{

}
