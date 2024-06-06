using AutoMapper;
using Mint.Application.Interfaces;
using Mint.Domain.Common;
using Mint.Domain.Extensions;
using Mint.Domain.Helpers;
using Mint.WebApp.Admin.Application.Operations.Dtos.Products;
using Mint.WebApp.Admin.Application.Operations.Repositories;
using Mint.WebApp.Admin.Application.Operations.Sorting.Products;

namespace Mint.WebApp.Admin.Application.Operations.Queries.Products;

public sealed record GetProductsQuery(
    Guid UserId,
    string? SearchPhrase,
    string? SortBy,
    SortDirection? SortDir,
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
            pageIndex: request.PageIndex,
            pageSize: request.PageSize,
            cancellationToken: cancellationToken
        );

        var sortDir = request.SortDir ?? SortDirection.Ascending;
        var sortProp = ProductDbSorter.Instance.GetSortingProperty(request.SortBy).Compile();

        var res = _mapper.Map<List<ProductViewModel>>(products.SortBy(sortProp!, sortDir));

        return new PaginatedResult<ProductViewModel>(res, totalCount);
    }
}