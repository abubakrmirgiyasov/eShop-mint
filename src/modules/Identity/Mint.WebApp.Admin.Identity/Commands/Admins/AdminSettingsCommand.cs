using Mint.Infrastructure.MessageBrokers.Interfaces;
using Mint.WebApp.Admin.Identity.Commands.Dtos;
using Mint.WebApp.Admin.Identity.Commands.Validations.Admins;
using Mint.WebApp.Admin.Identity.Repositories.Interfaces;

namespace Mint.WebApp.Admin.Identity.Commands.Admins;

public sealed record AdminSettingsCommand(Guid UserId, AdminSettingsDto Settings) : ICommand;

internal sealed class AdminSettingsCommandHandler(IAdminRepository adminRepository)
    : ICommandHandler<AdminSettingsCommand>
{
    private readonly IAdminRepository _adminRepository = adminRepository;

    public async Task HandleAsync(AdminSettingsCommand command, CancellationToken cancellationToken = default)
    {
        var validator = new AdminSettingsCommandValidator();

        if (validator.Validate(command).IsValid)
            return;

        await _adminRepository.UpdateSettingsAsync(command.UserId, command.Settings, cancellationToken);
    }
}