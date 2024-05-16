using Mint.Application.Interfaces;
using Mint.Domain.Exceptions;
using Mint.WebApp.Admin.Application.Operations.Dtos.Products;
using Mint.WebApp.Admin.Application.Operations.Repositories;

namespace Mint.WebApp.Admin.Application.Operations.Commands.Products;

public sealed record UpdateProductInfoCommand(Guid ProductId, ProductInfoBindingModel Product) : ICommand;

internal sealed class UpdateProductInfoCommandHandler(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork
) : ICommandHandler<UpdateProductInfoCommand>
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Handle(UpdateProductInfoCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.FirstOrDefaultAsync(x => x.Id == request.ProductId, cancellationToken)
            ?? throw new NotFoundException("Товар не найден.");

        product.ShowOnHomePage = request.Product.ShowOnHomePage;
        product.IsPublished = request.Product.IsPublished;
        product.Type = request.Product.ProductType;
        product.ShortName = request.Product.ShortName;
        product.LongName = request.Product.LongName;
        product.Sku = request.Product.Sku;
        product.Gtin = request.Product.Gtin;
        product.ShortDescription = request.Product.ShortDescription;
        product.FullDescription = request.Product.FullDescription;
        product.AdminComment = request.Product.AdminComment;
        product.UpdateDateTime = DateTimeOffset.Now;

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}