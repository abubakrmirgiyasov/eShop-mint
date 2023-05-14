using Mint.Domain.BindingModels;
using Mint.Domain.FormingModels;
using Mint.Domain.Models;
using Mint.Infrastructure.Repositories.Interfaces;

namespace Mint.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _context;

    public OrderRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> CreateOrder(OrderProductBindingModel model)
    {
        try
        {
            var order = new OrderManager().FormingBindingModel(model);
            order.OrderProducts = new List<OrderProduct>();

            for (var i = 0; i < model.OrderProducts?.Count; i++)
            {
                order.OrderProducts.Add(new OrderProduct()
                {
                    OrderId = order.Id,
                    ProductId = model.OrderProducts[i].Id,
                });
            }

            await _context.AddAsync(order);
            await _context.SaveChangesAsync();
            return order.Id;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
