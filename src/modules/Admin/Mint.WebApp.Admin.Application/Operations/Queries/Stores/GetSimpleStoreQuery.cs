using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Mint.Domain.Exceptions;
using Mint.Infrastructure.Repositories.Admin;
using Mint.WebApp.Admin.Application.Common.Messaging;
using Mint.WebApp.Admin.Application.Operations.Dtos.Stores;

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
        var store = await _storeRepository.Context.Stores
            .Where(x => x.UserId == request.UserId)
            .ToListAsync(cancellationToken);

        if (store.Count == 0)
            throw new LogicException("Вы еще не продавец. Хотите открыть свой магазин?");

        return _mapper.Map<List<SimpleStoreViewModel>>(store);
    }
}