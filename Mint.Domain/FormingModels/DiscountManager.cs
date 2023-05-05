using Mint.Domain.BindingModels;
using Mint.Domain.Models;
using Mint.Domain.ViewModels;

namespace Mint.Domain.FormingModels;

public class DiscountManager
{
    public List<DiscountViewModel> FomingMultiViewModels(List<Discount> models)
    {
		try
		{
			var discounts = new List<DiscountViewModel>();

			for (int i = 0; i < models.Count; i++)
			{
				discounts.Add(new DiscountViewModel()
				{
					Id = models[i].Id,
					Name = models[i].Name,
					Percent = models[i].Percent,
					CreatedDate = models[i].CreatedDate,
					ActiveDateUntil = models[i].ActiveDateUntil,
				});
			}

			return discounts;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
    }

    public DiscountViewModel FomingSingleViewModel(Discount model)
    {
        try
        {
            return new DiscountViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                Percent = model.Percent,
                CreatedDate = model.CreatedDate,
                ActiveDateUntil = model.ActiveDateUntil,
            };
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public Discount FormingSingleBindingModel(DiscountBindingModel model)
    {
		try
		{
			return new Discount()
			{
				Id = model.Id,
				Name = model.Name!,
				Percent = model.Percent,
				ActiveDateUntil = model.UntilDate,
				CreatedDate = DateTime.Now,
			};
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
    }
}
