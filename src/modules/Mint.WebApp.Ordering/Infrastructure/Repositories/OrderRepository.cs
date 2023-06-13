using Mint.WebApp.Ordering.Infrastructure.Services;
using Mint.WebApp.Ordering.Interfaces;
using Mint.WebApp.Ordering.Models;

namespace Mint.WebApp.Ordering.Infrastructure.Repositories;

public class OrderRepository : BaseRepository<Order, Guid>, IOrderRepository
{
    public OrderRepository(IMongoDbContext context)
        : base(context) { }
}
