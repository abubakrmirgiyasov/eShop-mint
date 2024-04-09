using AutoMapper;
using Mint.Application.Interfaces;
using Mint.WebApp.Admin.Application.Operations.Dtos.Products;
using Mint.WebApp.Admin.Application.Operations.Repositories;

namespace Mint.WebApp.Admin.Application.Operations.Queries.Products;

public sealed record GetProductInfoQuery(
    Guid Id
) : IQuery<ProductInfoViewModel>;


internal sealed class GetProductInfoQueryHandler(
    IProductRepository productRepository,
    IMapper mapper
) : IQueryHandler<GetProductInfoQuery, ProductInfoViewModel>
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<ProductInfoViewModel> Handle(GetProductInfoQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetProductInfoAsync(
            productId: request.Id,
            cancellationToken: cancellationToken
        );

        return _mapper.Map<ProductInfoViewModel>(product);
    }
}
