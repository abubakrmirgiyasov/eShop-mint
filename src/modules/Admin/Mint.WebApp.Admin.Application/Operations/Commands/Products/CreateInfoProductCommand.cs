using Mint.Domain.Models.Admin.Products;
using Mint.Infrastructure.Repositories.Admin;
using Mint.WebApp.Admin.Application.Common.Messaging;
using Mint.WebApp.Admin.Application.Operations.Dtos.Products;
using Mint.WebApp.Admin.Application.Operations.Validations.Products;

namespace Mint.WebApp.Admin.Application.Operations.Commands.Products;

public sealed record CreateInfoProductCommand(
    ProductInfoBindingModel Model
) : ICommand<Guid>;

internal sealed class CreateInfoProductCommandHandler(
    IProductRepository productRepository
) : ICommandHandler<CreateInfoProductCommand, Guid>
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<Guid> Handle(CreateInfoProductCommand request, CancellationToken cancellationToken)
    {
        var validator = new ProductInfoValidator();
        var validatorValidate = validator.Validate(request.Model);

        if (!validatorValidate.IsValid)
            throw new Exception("validator error");

        var product = new Product
        {
            Id = Guid.NewGuid(),
            ShortName = request.Model.ShortName,
            LongName = request.Model.LongName,
            FullDescription = request.Model.FullDescription,
            Sku = request.Model.Sku,
            ShortDescription = request.Model.ShortDescription,
            Gtin = request.Model.Gtin,
        };

        product.UrlToProduct = $"nm_{product.ProductNumber}#uu_{product.Id}";

        await _productRepository.Context.Products.AddAsync(product, cancellationToken);
        await _productRepository.Context.SaveChangesAsync(cancellationToken);

        return product.Id;
    }
}
