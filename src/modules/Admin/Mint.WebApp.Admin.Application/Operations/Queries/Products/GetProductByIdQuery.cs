using AutoMapper;
using Mint.Application.Interfaces;
using Mint.Domain.Exceptions;
using Mint.WebApp.Admin.Application.Operations.Dtos.Products;
using Mint.WebApp.Admin.Application.Operations.Repositories;

namespace Mint.WebApp.Admin.Application.Operations.Queries.Products;

public sealed record GetProductByIdQuery(Guid ProductId) : IQuery<ProductViewModel>;

internal sealed class GetProductByIdQueryHandler(
    IProductRepository productRepository,
    IMapper mapper
) : IQueryHandler<GetProductByIdQuery, ProductViewModel>
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<ProductViewModel> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.FirstOrDefaultAsync(x => x.Id == request.ProductId, cancellationToken)
            ?? throw new NotFoundException("Товар не найден.");

        return _mapper.Map<ProductViewModel>(product);
    }
}