using AutoMapper;
using Mint.Application.Interfaces;
using Mint.Domain.Exceptions;
using Mint.WebApp.Admin.Application.Operations.Dtos.Products;
using Mint.WebApp.Admin.Application.Operations.Repositories;

namespace Mint.WebApp.Admin.Application.Operations.Queries.Products;

public sealed record GetProductPriceQuery(Guid ProductId) : IQuery<ProductPriceViewModel>;

internal sealed class GetProductPriceQueryHandler(
    IProductRepository productRepository,
    IDiscountRepository discountRepository,
    IMapper mapper
) : IQueryHandler<GetProductPriceQuery, ProductPriceViewModel>
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IDiscountRepository _discountRepository = discountRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<ProductPriceViewModel> Handle(
        GetProductPriceQuery request,
        CancellationToken cancellationToken)
    {
        var product = await _productRepository.FirstOrDefaultAsync(
            x => x.Id == request.ProductId,
            cancellationToken
        ) ?? throw new NotFoundException("Товар не найден.");

        var discount = await _discountRepository
            .GetDiscountByProductIdAsync(request.ProductId, cancellationToken);

        product.Discount = discount;

        return _mapper.Map<ProductPriceViewModel>(product);
    }
}
