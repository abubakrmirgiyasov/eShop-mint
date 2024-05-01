using AutoMapper;
using Mint.Application.Interfaces;
using Mint.WebApp.Admin.Application.Operations.Dtos.Discounts;
using Mint.WebApp.Admin.Application.Operations.Repositories;

namespace Mint.WebApp.Admin.Application.Operations.Queries.Discounts;

public sealed record GetDiscountsByUserIdQuery(Guid UserId) 
    : IQuery<List<SimpleDiscountViewModel>>;

internal sealed class GetDiscountsByUserIdQueryHandler(
    IDiscountRepository discountRepository,
    IMapper mapper
) : IQueryHandler<GetDiscountsByUserIdQuery, List<SimpleDiscountViewModel>>
{
    private readonly IDiscountRepository _discountRepository = discountRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<SimpleDiscountViewModel>> Handle(GetDiscountsByUserIdQuery request, CancellationToken cancellationToken)
    {
        var discounts = await _discountRepository.GetDiscountsByUserIdAsync(request.UserId, cancellationToken);

        return _mapper.Map<List<SimpleDiscountViewModel>>(discounts);
    }
}