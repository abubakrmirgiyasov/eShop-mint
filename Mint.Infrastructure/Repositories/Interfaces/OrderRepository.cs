using Mint.Domain.BindingModels;

namespace Mint.Infrastructure.Repositories.Interfaces;

public interface IOrderRepository
{
    Task<Guid> CreateOrder(OrderProductBindingModel model);
}
