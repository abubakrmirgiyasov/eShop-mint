using AutoMapper;
using Mint.Application.Interfaces;
using Mint.Domain.Common;
using Mint.Domain.Helpers;
using Mint.WebApp.Admin.Application.Operations.Dtos.Products;
using Mint.WebApp.Admin.Application.Operations.Repositories;

namespace Mint.WebApp.Admin.Application.Operations.Queries.Products;

public sealed record GetProductsQuery(
    Guid UserId,
    string? SearchPhrase,
    SortType Sort,
    int PageIndex,
    int PageSize
) : IQuery<PaginatedResult<ProductViewModel>>;

internal sealed class GetProductsQueryHandler(
  IProductRepository productRepository,
  IMapper mapper
) : IQueryHandler<GetProductsQuery, PaginatedResult<ProductViewModel>>
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<PaginatedResult<ProductViewModel>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var (products, totalCount) = await _productRepository.GetProductsAsync(
            userId: request.UserId,
            searchPhrase: request.SearchPhrase,
            sort: request.Sort,
            pageIndex: request.PageIndex,
            pageSize: request.PageSize,
            cancellationToken: cancellationToken
        );

        return new PaginatedResult<ProductViewModel>
        {
            Items = _mapper.Map<List<ProductViewModel>>(products),
            TotalCount = totalCount
        };
    }
}