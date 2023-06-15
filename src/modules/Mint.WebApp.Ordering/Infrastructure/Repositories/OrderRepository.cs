using Mint.WebApp.Ordering.Common;
using Mint.WebApp.Ordering.Infrastructure.Interfaces;
using Mint.WebApp.Ordering.Infrastructure.Repositories.Interfaces;
using Mint.WebApp.Ordering.Infrastructure.Services;
using Mint.WebApp.Ordering.Models;

namespace Mint.WebApp.Ordering.Infrastructure.Repositories;

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(IMongoDbSettings settings) 
        : base(settings) { }
}
