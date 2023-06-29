using Mint.Domain.BindingModels;
using Mint.Domain.Models;
using Mint.Domain.ViewModels;

namespace Mint.Domain.FormingModels;

public class OrderManager
{
    public Order FormingBindingModel(OrderProductBindingModel model)
    {
		try
		{
			return new Order()
			{
				Id = Guid.NewGuid(),
				PaymentType = model.PaymentType!,
				Description = model.Description,
				ShippingType = model.ShippingType!,
				UserId = model.UserId,
				AddressId = model.AddressId,
				OrderStatus = model.OrderStatus,
			};
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
    }

    public List<OrderFullViewModel> FormingMultiOrdersViewModels(List<Order> models)
    {
		try
		{
			var orders = new List<OrderFullViewModel>();

			for (int i = 0; i < models.Count; i++)
			{
				orders.Add(new OrderFullViewModel()
				{
					Id = models[i].Id,
					OrderNumber = models[i].OrderNumber,
					Description = models[i].Description,
					ShippingType = models[i].ShippingType,
					PaymentType = models[i].PaymentType,
					DateCreate = models[i].CreatedDate.Date,
					OrderProducts = new List<OrderProductFullViewModel>(),
				});

				for (int j = 0; j < models[i].OrderProducts?.Count; j++)
				{
					orders[i].OrderProducts?.Add(new OrderProductFullViewModel()
					{
						Quantity = models[i].OrderProducts[j].Quantity,
						Percent = models[i].OrderProducts[j].Percent,
						Price = models[i].OrderProducts[j].Price,
						Sum = models[i].OrderProducts[j].Sum,
						Product = new ProductManager().FormingSingleFullViewModel(models[i].OrderProducts[j].Product),
						Store = new StoreManager().FormingViewModel(models[i].OrderProducts[j].Store),
					});
				}
            }

			return orders;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
    }
}
