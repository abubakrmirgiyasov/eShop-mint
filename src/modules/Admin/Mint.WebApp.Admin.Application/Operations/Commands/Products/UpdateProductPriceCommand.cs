using FluentValidation;
using Mint.Application.Interfaces;
using Mint.Domain.Exceptions;
using Mint.Domain.Extensions;
using Mint.WebApp.Admin.Application.Operations.Dtos.Products;
using Mint.WebApp.Admin.Application.Operations.Repositories;
using Mint.WebApp.Admin.Application.Operations.Validations.Products;

namespace Mint.WebApp.Admin.Application.Operations.Commands.Products;

public sealed record UpdateProductPriceCommand(Guid ProductId, ProductPriceBindingModel Product) : ICommand;

internal sealed class UpdateProductPriceCommandHandler(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork
) : ICommandHandler<UpdateProductPriceCommand>
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Handle(UpdateProductPriceCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateProductPriceCommandValidator();
        var validatorValidation = validator.Validate(request);

        if (!validatorValidation.IsValid)
            throw new ValidationException(validatorValidation.Errors);

        var product = await _productRepository.FirstOrDefaultAsync(x => x.Id == request.ProductId, cancellationToken)
            ?? throw new NotFoundException("Товар не найден.");

        var specialDateFrom = request.Product.SpecialDate?.From.ToDateTime(TimeOnly.MinValue, DateTimeKind.Local);
        var specialDateTo = request.Product.SpecialDate?.To.ToDateTime(TimeOnlyExtensions.EndOfDay, DateTimeKind.Local);

        product.IsFreeTax = request.Product.IsFreeTax;
        product.TaxPrice = !request.Product.IsFreeTax ? request.Product.TaxPrice : null;
        product.Price = request.Product.Price;
        product.OldPrice = request.Product.Price;
        product.DeliveryMinDay = request.Product.Delivery.First();
        product.DeliveryMaxDay = request.Product.Delivery.Last();
        product.SpecialPrice = request.Product.SpecialPrice;
        product.SpecialPriceStartDateTimeUtc = request.Product.SpecialPrice != null ? specialDateFrom : null;
        product.SpecialPriceEndDateTimeUtc = request.Product.SpecialPrice != null ? specialDateTo : null;
        product.DisableBuyButton = request.Product.DisableBuyButton;
        product.CustomerEntersPrice = request.Product.CustomerPrice;
        product.MinCustomerEntersPrice = request.Product.CustomerPrice ? request.Product.CustomerPriceMin : null;
        product.MaxCustomerEntersPrice = request.Product.CustomerPrice ? request.Product.CustomerPriceMax : null;
        product.DiscountId = request.Product.DiscountId;

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
