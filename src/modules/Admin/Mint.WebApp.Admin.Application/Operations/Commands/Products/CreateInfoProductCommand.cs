using FluentValidation;
using Mint.Application.Interfaces;
using Mint.Domain.Models.Admin.Products;
using Mint.WebApp.Admin.Application.Operations.Dtos.Products;
using Mint.WebApp.Admin.Application.Operations.Repositories;
using Mint.WebApp.Admin.Application.Operations.Validations.Products;

namespace Mint.WebApp.Admin.Application.Operations.Commands.Products;

public sealed record CreateInfoProductCommand(
    ProductInfoBindingModel Model
) : ICommand<Guid>;

internal sealed class CreateInfoProductCommandHandler(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork
) : ICommandHandler<CreateInfoProductCommand, Guid>
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Guid> Handle(CreateInfoProductCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateProductInfoCommandValidation();
        var validatorValidate = validator.Validate(request.Model);

        if (!validatorValidate.IsValid)
            throw new ValidationException(validatorValidate.Errors);

        var product = new Product
        {
            Id = Guid.NewGuid(),
            Type = request.Model.ProductType,
            ShortName = request.Model.ShortName,
            LongName = request.Model.LongName,
            FullDescription = request.Model.FullDescription,
            Sku = request.Model.Sku,
            ShortDescription = request.Model.ShortDescription,
            Gtin = request.Model.Gtin,
            StoreId = request.Model.Store,
            AdminComment = request.Model.AdminComment,
        };

        product.UrlToProduct = $"nm#uu_{product.Id}";

        await _productRepository.AddAsync(product, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return product.Id;
    }
}
