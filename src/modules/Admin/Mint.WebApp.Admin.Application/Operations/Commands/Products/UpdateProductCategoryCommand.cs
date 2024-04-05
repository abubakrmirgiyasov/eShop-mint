using Microsoft.EntityFrameworkCore;
using Mint.Domain.Exceptions;
using Mint.Domain.Models.Admin.Products;
using Mint.Infrastructure.Repositories.Admin;
using Mint.WebApp.Admin.Application.Common.Messaging;
using Mint.WebApp.Admin.Application.Operations.Dtos.Products;

namespace Mint.WebApp.Admin.Application.Operations.Commands.Products;

public sealed record UpdateProductCategoryCommand(
    Guid ProductId,
    List<ProductCategoryBindingModel> CategoriesIds
) : ICommand;

internal sealed class UpdateProductCategoryCommandHandler(
    IProductRepository productRepository
) : ICommandHandler<UpdateProductCategoryCommand>
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.Context.Products
            .Include(x => x.ProductCategories)
            .FirstOrDefaultAsync(x => x.Id == request.ProductId, cancellationToken)
                ?? throw new NotFoundException("Товар не найден.");

        if (product.ProductCategories is null)
        {
            product.ProductCategories = FillProductCategories(product.Id, request.CategoriesIds);
        }
        else
        {
            product.ProductCategories.Clear();
            product.ProductCategories.AddRange(FillProductCategories(product.Id, request.CategoriesIds));
        }

        await _productRepository.Context.SaveChangesAsync(cancellationToken);
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
                    CategoryId = category.CategoryId,
                    ProductId = productId,
                }
            );
        }

        return productCategories;
    }
}
