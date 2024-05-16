using AutoMapper;
using Mint.Application.Interfaces;
using Mint.Domain.Exceptions;
using Mint.WebApp.Admin.Application.Operations.Repositories;
using Mint.WebApp.Admin.Identity.Application.Operations.Dtos;

namespace Mint.WebApp.Admin.Identity.Application.Operations.Queries;

public sealed record GetConsumerInfoQuery(Guid Id) : IQuery<AdminInfoViewModel>;

internal sealed class GetConsumerInfoQueryHandler(
    IAdminRepository adminRepository,
    IMapper mapper
) : IQueryHandler<GetConsumerInfoQuery, AdminInfoViewModel>
{
    private readonly IAdminRepository _adminRepository = adminRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<AdminInfoViewModel> Handle(GetConsumerInfoQuery request, CancellationToken cancellationToken)
    {
        var user = await _adminRepository.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
            ?? throw new NotFoundException("Пользователь не найден.");

        return _mapper.Map<AdminInfoViewModel>(user);
    }
}