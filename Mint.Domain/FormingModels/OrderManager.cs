using Mint.Domain.BindingModels;
using Mint.Domain.Models;

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
				Quantity = model.Quantity,
				Description = model.Description,
				//Price = model.Pr,
				Sum = model.Sum,
				ShippingType = model.ShippingType!,
				StoreId = model.StoreId,
				UserId = model.UserId,
				AddressId = model.AddressId,
			};
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
    }
}
