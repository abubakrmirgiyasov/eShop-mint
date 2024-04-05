using Mint.Infrastructure.Repositories.Admin;
using Mint.WebApp.Admin.Application.Common.Messaging;
using Mint.WebApp.Admin.Application.Operations.Dtos.Products;
using Mint.WebApp.Admin.Application.Operations.Validations.Products;

namespace Mint.WebApp.Admin.Application.Operations.Commands.Products;

public sealed record UpdateInfoProductCommand(ProductInfoBindingModel Product) : ICommand;

internal sealed class UpdateInfoProductCommandHandler(IProductRepository productRepository) : ICommandHandler<UpdateInfoProductCommand>
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task Handle(UpdateInfoProductCommand request, CancellationToken cancellationToken)
    {
        var validator = new ProductInfoValidator();
        var validatorValidate = validator.Validate(request.Product);

        if (!validatorValidate.IsValid)
            throw new Exception("validator error!");

        // TODO: Update fields ...

        await _productRepository.Context.SaveChangesAsync(cancellationToken);
    }
}