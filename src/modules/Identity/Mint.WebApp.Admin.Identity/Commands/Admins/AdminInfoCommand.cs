using AutoMapper;
using Mint.Infrastructure.Messaging;
using Mint.WebApp.Admin.Identity.Commands.Dtos;
using Mint.WebApp.Admin.Identity.Repositories.Interfaces;

namespace Mint.WebApp.Admin.Identity.Commands.Admins;

public sealed record AdminInfoCommand(Guid Id): ICommand<AdminInfoDto>;

internal sealed class AdminInfoCommandHandler(
    IAdminRepository adminRepository,
    IMapper mapper
) : ICommandHandler<AdminInfoCommand, AdminInfoDto>
{
    private readonly IAdminRepository _adminRepository = adminRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<AdminInfoDto> Handle(AdminInfoCommand request, CancellationToken cancellationToken)
    {
        var user = await _adminRepository.FindByIdAsync(request.Id, cancellationToken);

        return _mapper.Map<AdminInfoDto>(user);
    }
}
