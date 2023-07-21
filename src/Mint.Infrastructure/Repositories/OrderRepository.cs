//using Microsoft.EntityFrameworkCore;
//using Mint.Domain.BindingModels;
//using Mint.Domain.FormingModels;
//using Mint.Domain.Models;
//using Mint.Domain.ViewModels;
//using Mint.Infrastructure.Repositories.Interfaces;

//namespace Mint.Infrastructure.Repositories;

//public class OrderRepository : IOrderRepository
//{
//    private readonly ApplicationDbContext _context;

//    public OrderRepository(ApplicationDbContext context)
//    {
//        _context = context;
//    }

//    public async Task<List<OrderFullViewModel>> GetOrdersAsync()
//    {
//        try
//        {
//            var orders = await _context.Orders
//                .AsNoTracking()
//                .Include(x => x.OrderProducts)
//                .ThenInclude(x => x.Product)
//                .ThenInclude(x => x.ProductPhotos!)
//                .ThenInclude(x => x.Photo)
//                .Include(x => x.Address)
//                .Include(x => x.User)
//                .Include(x => x.OrderProducts)
//                .ThenInclude(x => x.Store)
//                .ToListAsync();
//            return new OrderManager().FormingMultiOrdersViewModels(orders);
//        }
//        catch (Exception ex)
//        {
//            throw new Exception(ex.Message, ex);
//        }
//    }

//    public async Task<List<OrderFullViewModel>> GetSellerOrdersByIdAsync(Guid id)
//    {
//        try
//        {
//            var orders = await _context.Orders
//                .AsNoTracking()
//                .Include(x => x.OrderProducts)
//                .ThenInclude(x => x.Product)
//                .ThenInclude(x => x.ProductPhotos!)
//                .ThenInclude(x => x.Photo)
//                .Include(x => x.Address)
//                .Include(x => x.User)
//                .Include(x => x.OrderProducts)
//                .ThenInclude(x => x.Store)
//                .Where(x => x.UserId == id)
//                .ToListAsync();
//            return new OrderManager().FormingMultiOrdersViewModels(orders);
//        }
//        catch (Exception ex)
//        {
//            throw new Exception(ex.Message, ex);
//        }
//    }

//    public async Task<List<OrderFullViewModel>> GetBuyerOrdersByIdAsync(Guid id)
//    {
//        try
//        {
//            var orders = await _context.Orders
//                .AsNoTracking()
//                .Include(x => x.OrderProducts)
//                .ThenInclude(x => x.Product)
//                .ThenInclude(x => x.ProductPhotos!)
//                .ThenInclude(x => x.Photo)
//                .Include(x => x.Address)
//                .Include(x => x.User)
//                .Include(x => x.OrderProducts)
//                .ThenInclude(x => x.Store)
//                .Where(x => x.UserId == id)
//                .ToListAsync();
//            return new OrderManager().FormingMultiOrdersViewModels(orders);
//        }
//        catch (Exception ex)
//        {
//            throw new Exception(ex.Message, ex);
//        }
//    }

//    public async Task<Guid> CreateOrder(OrderProductBindingModel model)
//    {
//        try
//        {
//            var order = new OrderManager().FormingBindingModel(model);
//            order.OrderProducts = new List<OrderProduct>();

//            for (var i = 0; i < model.OrderProducts?.Count; i++)
//            {
//                order.OrderProducts.Add(new OrderProduct()
//                {
//                    Id = Guid.NewGuid(),
//                    StoreId = model.OrderProducts[i].StoreId,
//                    Sum = model.OrderProducts[i].Sum,
//                    Quantity = model.OrderProducts[i].Quantity,
//                    Price = model.OrderProducts[i].Price,
//                    OrderId = order.Id,
//                    ProductId = model.OrderProducts[i].Id,
//                    Percent = model.OrderProducts[i].Percent,
//                });
//            }

//            await _context.AddAsync(order);
//            await _context.SaveChangesAsync();
//            return order.Id;
//        }
//        catch (Exception ex)
//        {
//            throw new Exception(ex.Message, ex);
//        }
//    }
//}
