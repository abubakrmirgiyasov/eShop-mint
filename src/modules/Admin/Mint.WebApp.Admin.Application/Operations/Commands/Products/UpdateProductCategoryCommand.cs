using Mint.Application.Interfaces;
using Mint.Domain.Models.Admin.Products;
using Mint.WebApp.Admin.Application.Operations.Dtos.Products;
using Mint.WebApp.Admin.Application.Operations.Repositories;

namespace Mint.WebApp.Admin.Application.Operations.Commands.Products;

public sealed record UpdateProductCategoryCommand(
    Guid ProductId,
    List<ProductCategoryBindingModel> ProductCategories
) : ICommand;

internal sealed class UpdateProductCategoryCommandHandler(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork
) : ICommandHandler<UpdateProductCategoryCommand>
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetProductWithCategoriesAsync(request.ProductId, cancellationToken);

        if (product.ProductCategories is null)
        {
            product.ProductCategories = FillProductCategories(product.Id, request.ProductCategories);
        }
        else
        {
            product.ProductCategories.Clear();
            product.ProductCategories.AddRange(FillProductCategories(product.Id, request.ProductCategories));
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    private static List<ProductCategory> FillProductCategories(Guid productId, List<ProductCategoryBindingModel> categoriesIds)
    {
        var productCategories = new List<ProductCategory>();

        foreach (var category in categoriesIds)
        {
            productCategories.Add(
                new ProductCategory
                {
                    DisplayOrder = category.DisplayOrder,
                    CategoryId = category.Category.Value,
                    ProductId = productId,
                }
            );
        }

        return productCategories;
    }
}
