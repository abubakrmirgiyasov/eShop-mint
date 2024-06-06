using AutoMapper;
using Mint.Application.Interfaces;
using Mint.Domain.Common;
using Mint.Domain.Extensions;
using Mint.Domain.Helpers;
using Mint.WebApp.Admin.Application.Operations.Dtos.Products.ProductReviews;
using Mint.WebApp.Admin.Application.Operations.Repositories;
using Mint.WebApp.Admin.Application.Operations.Sorting.ProductReviews;

namespace Mint.WebApp.Admin.Application.Operations.Queries.Products.ProductReviews;

public sealed record GetProductReviewsQuery(
    DateOnly From,
    DateOnly To,
    Guid SellerId,
    string? SearchPhrase,
    string? SortBy,
    SortDirection? SortDir,
    int[] Rating,
    bool OnlyPluses,
    bool OnlyMinuses,
    int PageIndex,
    int PageSize
) : IQuery<PaginatedResult<ProductReviewViewModel>>;

internal sealed class GetProductReviewsQueryHandler(
    IProductReviewRepository productReviewRepository,
    IMapper mapper
) : IQueryHandler<GetProductReviewsQuery, PaginatedResult<ProductReviewViewModel>>
{
    private readonly IProductReviewRepository _productReviewRepository = productReviewRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<PaginatedResult<ProductReviewViewModel>> Handle(GetProductReviewsQuery request, CancellationToken cancellationToken)
    {
        var from = request.From.ToDateTime(TimeOnly.MinValue, DateTimeKind.Local);
        var to = request.To.ToDateTime(TimeOnlyExtensions.EndOfDay, DateTimeKind.Local);

        var (reviews, totalCount) = await _productReviewRepository.GetProductReviewsAsync(
            from: from,
            to: to,
            sellerId: request.SellerId,
            rating: request.Rating,
            onlyPluses: request.OnlyPluses,
            onlyMinuses: request.OnlyMinuses,
            searchPhrase: request.SearchPhrase,
            pageIndex: request.PageIndex,
            pageSize: request.PageSize,
            cancellationToken: cancellationToken
        );

        var sortDir = request.SortDir ?? SortDirection.Ascending;
        var sortProp = ProductReviewSorter.Instance.GetSortingProperty(request.SortBy).Compile();

        var res = _mapper.Map<List<ProductReviewViewModel>>(reviews.SortBy(sortProp!, sortDir));

        return new PaginatedResult<ProductReviewViewModel>(res, totalCount);
    }
}