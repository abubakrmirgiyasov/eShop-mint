using AutoMapper;
using Mint.Application.Interfaces;
using Mint.Domain.Exceptions;
using Mint.WebApp.Admin.Application.Operations.Dtos.Stores;
using Mint.WebApp.Admin.Application.Operations.Repositories;

namespace Mint.WebApp.Admin.Application.Operations.Queries.Stores;

public sealed record GetSimpleStoreQuery(Guid UserId) : IQuery<List<SimpleStoreViewModel>>;

internal sealed class GetSimpleStoreQueryHandler(
    IStoreRepository storeRepository,
    IMapper mapper
) : IQueryHandler<GetSimpleStoreQuery, List<SimpleStoreViewModel>>
{
    private readonly IStoreRepository _storeRepository = storeRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<SimpleStoreViewModel>> Handle(GetSimpleStoreQuery request, CancellationToken cancellationToken)
    {
        var stores = await _storeRepository.GetSampleStoreAsync(request.UserId, cancellationToken);

        if (stores.Count == 0)
            throw new LogicException("Вы еще не продавец. Хотите открыть свой магазин?");

        return _mapper.Map<List<SimpleStoreViewModel>>(stores);
    }
}