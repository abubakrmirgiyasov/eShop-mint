using AutoMapper;
using Mint.Infrastructure.Repositories.Admin;
using Mint.WebApp.Admin.Application.Common.Messaging;
using Mint.WebApp.Admin.Application.Operations.Dtos.Products;

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
        var product = await _productRepository.FindByIdAsync(
            id: request.Id,
            asNoTracking: true,
            cancellationToken: cancellationToken
        );

        return _mapper.Map<ProductInfoViewModel>(product);
    }
}
