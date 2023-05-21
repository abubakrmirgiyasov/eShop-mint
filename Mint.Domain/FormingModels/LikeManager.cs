using Mint.Domain.BindingModels;
using Mint.Domain.Models;
using Mint.Domain.ViewModels;

namespace Mint.Domain.FormingModels;

public class LikeManager
{
    public LikedProduct FormingBindingModel(LikeBindingModel model)
    {
        return new LikedProduct()
        {
            Id = Guid.NewGuid(),
            CreateDate = DateTime.Now,
            ProductId = model.ProductId,
            UserId = model.UserId,
        };
    }

    public List<LikeViewModel> FormingMultiViewModel(List<LikedProduct> models)
    {
        try
        {
            var likes = new List<LikeViewModel>();

            for (int i = 0; i < models.Count; i++)
            {
                likes.Add(new LikeViewModel()
                {
                    Id = models[i].Id,
                    ProductId = models[i].ProductId,
                    UserId = models[i].UserId,
                    Product = new ProductManager().FormingSingleFullViewModel(models[i].Product!),
                });
            }

            return likes;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public List<LikeViewModel> FormingSingleViewModel(LikedProduct likes)
    {
        try
        {
            return new List<LikeViewModel>();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
