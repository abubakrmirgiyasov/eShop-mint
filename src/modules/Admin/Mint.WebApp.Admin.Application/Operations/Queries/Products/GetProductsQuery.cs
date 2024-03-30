using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Mint.Domain.Helpers;
using Mint.Infrastructure.Repositories.Admin;
using Mint.WebApp.Admin.Application.Common.Messaging;
using Mint.WebApp.Admin.Application.Operations.Dtos.Products;

namespace Mint.WebApp.Admin.Application.Operations.Queries.Products;

public sealed record GetProductsQuery(
    string? SearchPhrase,
    int Sort,
    int PageIndex,
    int PageSize
) : IQuery<PaginatedResult<ProductFullViewModel>>;

internal sealed class GetProductsQueryHandler(
  IProductRepository productRepository,
  IMapper mapper
) : IQueryHandler<GetProductsQuery, PaginatedResult<ProductFullViewModel>>
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IMapper _mapper = mapper;

    private const int Ascending = 1;
    private const int Descending = -1;

    public async Task<PaginatedResult<ProductFullViewModel>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var query = _productRepository.Context.Products.AsQueryable();

        if (!string.IsNullOrEmpty(request.SearchPhrase))
        {
            query = query.Where(x => 
                x.ShortName.Contains(request.SearchPhrase)
                || x.LongName.Contains(request.SearchPhrase)
                || x.ShortDescription.Contains(request.SearchPhrase)
                || x.FullDescription.Contains(request.SearchPhrase)
            );

            if (request.Sort == Ascending)
                query = query.OrderBy(x => x.ProductNumber);

            if (request.Sort == Descending)
                query = query.OrderByDescending(x => x.ProductNumber);
        }

        var products = await query
            .AsNoTracking()
            .Include(x => x.Category)
            .Include(x => x.Manufacture)
            .Include(x => x.CommonCharacteristics)
            .Include(x => x.ProductCharacteristics)
            .Include(x => x.ProductPhotos)
            .Skip(request.PageIndex * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        var totalCount = await _productRepository.Context.Products.CountAsync(cancellationToken);

        return new PaginatedResult<ProductFullViewModel>
        {
            Items = _mapper.Map<List<ProductFullViewModel>>(products),
            TotalCount = totalCount
        };
    }
}