using Mint.Domain.BindingModels;
using Mint.Domain.Common;
using Mint.Domain.Models;
using Mint.Domain.ViewModels;

namespace Mint.Domain.FormingModels;

public class ProductManager
{
    public List<ProductFullViewModel> FormingCategoryViewModels(List<Category> models)
    {
        try
        {
            var products = new List<ProductFullViewModel>();

            for (int i = 0; i < models.Count; i++)
            {

            }

            return products;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public CommonCharacteristic FormingCharacteristicsBindingModel(CommonCharacteristic? commonCharacteristic, CommonCharacteristicFullBindingModel model)
    {
        try
        {
            if (commonCharacteristic == null)
            {
                return new CommonCharacteristic()
                {
                    Id = Guid.NewGuid(),
                    Material = model.Material,
                    Color = model.Color,
                    Garanty = model.Garanty,
                    Availability = model.Availability,
                    Weight = model.Weight,
                    Length = model.Length,
                    Width = model.Width,
                    Height = model.Height,
                    Rate = model.Rate,
                    ReleaseDate = model.ReleaseDate,
                };
            }
            else
            {
                commonCharacteristic.Material = model.Material ?? commonCharacteristic.Material;
                commonCharacteristic.Color = model.Color ?? commonCharacteristic.Color;
                commonCharacteristic.Garanty = model.Garanty == commonCharacteristic.Garanty ? model.Garanty : commonCharacteristic.Garanty;
                commonCharacteristic.Availability = model.Availability;
                commonCharacteristic.Weight = model.Weight == commonCharacteristic.Weight ? model.Weight : commonCharacteristic.Weight;
                commonCharacteristic.Length = model.Length == commonCharacteristic.Length ? model.Length : commonCharacteristic.Length;
                commonCharacteristic.Width = model.Width == commonCharacteristic.Width ? model.Width : commonCharacteristic.Width;
                commonCharacteristic.Height = model.Height == commonCharacteristic.Height ? model.Height : commonCharacteristic.Height;
                commonCharacteristic.Rate = model.Rate == commonCharacteristic.Rate ? model.Rate : commonCharacteristic.Rate;
                commonCharacteristic.ReleaseDate = model.ReleaseDate == commonCharacteristic.ReleaseDate ? model.ReleaseDate : commonCharacteristic.ReleaseDate;
                return commonCharacteristic;
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public List<ProductFullViewModel> FormingFullProdutcViewModels(List<Product> models)
    {
        try
        {
            var products = new List<ProductFullViewModel>();

            for (int i = 0; i < models.Count; i++)
            {
                products.Add(new ProductFullViewModel()
                {
                    Id = models[i].Id,
                    Name = models[i].Name,
                    Sku = models[i].Sku,
                    Gtin = models[i].Gtin,
                    ShortDescription = models[i].ShortDescription,
                    FullDescription = models[i].FullDescription,
                    AdminComment = models[i].AdminComment,
                    ShowOnHomePage = models[i].ShowOnHomePage,
                    CountryOfOrigin = models[i].CountryOfOrigin,
                    Store = models[i].Store?.Name,
                    TaxPrice = models[i].TaxPrice,
                    Price = models[i].Price,
                    OldPrice = models[i].Price,
                    DateCreate = models[i].DateCreate,
                    Category = models[i].Category?.Name,
                    DeliveryMinDay = models[i].DeliveryMinDay,
                    DeliveryMaxDay = models[i].DeliveryMaxDay,
                    Discount = models[i].Discount?.Name,
                    IsFreeTax = models[i].IsFreeTax,
                    IsPublished = models[i].IsPublished,
                    Manufacture = models[i].Manufacture?.Name,
                    //Quantity = models[i].Storages?.FirstOrDefault
                    Photos = new List<string>(),
                });

                for (int j = 0; j < models[i].ProductPhotos?.Count; j++)
                {
                    products[i].Photos?.Add(models[i].ProductPhotos![j].Photo.GetImage64());
                }
            }

            return products;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public Product FormingInfoBindingModel(ProductInfoBindingModel model)
    {
        try
        {
            return new Product()
            {
                Id = Guid.NewGuid(),
                Name = model.Name!,
                Sku = model.Sku!,
                Gtin = model.Gtin.ToString(),
                IsPublished = model.IsPublished,
                ShortDescription = model.ShortDescription!,
                FullDescription = model.FullDescription!,
                AdminComment = model.AdminComment!,
                DeliveryMaxDay = model.DeliveryMaxDay,
                DeliveryMinDay = model.DeliveryMinDay,
            };
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public ProductFullViewModel FormingInfoViewModel(Product model)
    {
        return new ProductFullViewModel();
    }

    public List<ProductFullViewModel> FormingMultiViewModels(Store model)
    {
        try
        {
            var products = new List<ProductFullViewModel>();

            for (int i = 0; i < model.Products?.Count; i++)
            {
                products.Add(new ProductFullViewModel()
                {
                    Id = model.Products![i].Id,
                    Name = model.Products![i].Name,
                    Sku = model.Products![i].Sku,
                    ShortDescription = model.Products![i].ShortDescription,
                    Price = model.Products![i].Price,
                    IsDiscount = model.Products![i].Discount != null,
                    Percent = model.Products![i].Discount?.Percent,
                });

                for (int j = 0; j < model.Products[i].ProductPhotos?.Count; j++)
                {
                    products[i].Photos?.Add(model.Products[i].ProductPhotos![j].Photo.GetImage64());
                }
            }

            return products;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public ProductFullViewModel FormingSingleFullViewModel(Product model)
    {
        try
        {
            var product = new ProductFullViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                Sku = model.Sku,
                Gtin = model.Gtin,
                ShortDescription = model.ShortDescription,
                FullDescription = model.FullDescription,
                AdminComment = model.AdminComment,
                ShowOnHomePage = model.ShowOnHomePage,
                CountryOfOrigin = model.CountryOfOrigin,
                Store = model.Store?.Name,
                TaxPrice = model.TaxPrice,
                Price = model.Price,
                OldPrice = model.Price,
                DateCreate = model.DateCreate,
                Category = model.Category?.Name,
                DeliveryMinDay = model.DeliveryMinDay,
                DeliveryMaxDay = model.DeliveryMaxDay,
                Discount = model.Discount?.Name,
                IsFreeTax = model.IsFreeTax,
                IsPublished = model.IsPublished,
                Manufacture = model.Manufacture?.Name,
                //Quantity = models[i].Storages?.FirstOrDefault
                Photos = new List<string>(),
            };

            for (int i = 0; i < model.ProductPhotos?.Count; i++)
            {
                product.Photos?.Add(model.ProductPhotos![i].Photo.GetImage64());
            }

            for (int i = 0; i < model.CommonCharacteristics?.Count; i++)
            {
                product.CommonCharacteristic = new CommonCharacteristicFullViewModel()
                {
                    Id = model.CommonCharacteristics[i].Id,
                    Material = model.CommonCharacteristics[i].Material,
                    Color = model.CommonCharacteristics[i].Color,
                    ReleaseDate = model.CommonCharacteristics[i].ReleaseDate,
                    Availability = model.CommonCharacteristics[i].Availability,
                    Garanty = model.CommonCharacteristics[i].Garanty,
                    Height = model.CommonCharacteristics[i].Height,
                    Weight = model.CommonCharacteristics[i].Weight,
                    Length = model.CommonCharacteristics[i].Length,
                    Width = model.CommonCharacteristics[i].Width,
                    Rate = model.CommonCharacteristics[i].Rate,
                };
            }

            return product;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
