using AutoMapper;
using Mint.Application.Interfaces;
using Mint.Domain.Exceptions;
using Mint.WebApp.Identity.Application.Operations.Dtos.Admins;
using Mint.WebApp.Identity.Application.Operations.Repositories;

namespace Mint.WebApp.Identity.Application.Operations.Queries.Admins;

public sealed record GetAdminInfoQuery(Guid Id) : IQuery<AdminInfoViewModel>;

internal sealed class GetAdminInfoQueryHandler(
    IAdminRepository adminRepository,
    IMapper mapper
) : IQueryHandler<GetAdminInfoQuery, AdminInfoViewModel>
{
    private readonly IAdminRepository _adminRepository = adminRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<AdminInfoViewModel> Handle(GetAdminInfoQuery request, CancellationToken cancellationToken)
    {
        var user = await _adminRepository.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
            ?? throw new NotFoundException("Пользователь не найден.");

        return _mapper.Map<AdminInfoViewModel>(user);
    }
}