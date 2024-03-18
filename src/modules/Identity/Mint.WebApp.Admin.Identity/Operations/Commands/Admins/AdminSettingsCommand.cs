using MediatR;
using Mint.WebApp.Admin.Identity.Operations.Dtos;
using Mint.WebApp.Admin.Identity.Operations.Validations.Admins;
using Mint.WebApp.Admin.Identity.Repositories.Interfaces;

namespace Mint.WebApp.Admin.Identity.Operations.Commands.Admins;

public sealed record AdminSettingsCommand(Guid UserId, AdminSettingsDto Settings) : IRequest;

internal sealed class AdminSettingsCommandHandler(IAdminRepository adminRepository)
    : IRequestHandler<AdminSettingsCommand>
{
    private readonly IAdminRepository _adminRepository = adminRepository;

    public async Task Handle(AdminSettingsCommand command, CancellationToken cancellationToken = default)
    {
        var validator = new AdminSettingsCommandValidator();

        if (validator.Validate(command).IsValid)
            return;

        await _adminRepository.UpdateSettingsAsync(command.UserId, command.Settings, cancellationToken);
    }
}