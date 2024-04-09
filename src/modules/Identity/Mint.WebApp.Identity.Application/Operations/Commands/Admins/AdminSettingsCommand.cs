using FluentValidation;
using Mint.Application.Interfaces;
using Mint.Domain.Exceptions;
using Mint.WebApp.Admin.Identity.Operations.Validations.Admins;
using Mint.WebApp.Identity.Application.Operations.Dtos.Admins;
using Mint.WebApp.Identity.Application.Operations.Repositories;

namespace Mint.WebApp.Admin.Identity.Operations.Commands.Admins;

public sealed record AdminSettingsCommand(
    Guid UserId,
    AdminSettingsBindingModel Settings
) : ICommand;

internal sealed class AdminSettingsCommandHandler(
    IAdminRepository adminRepository,
    IStorageCloudService storageCloudService,
    IUnitOfWork unitOfWork
) : ICommandHandler<AdminSettingsCommand>
{
    private readonly IAdminRepository _adminRepository = adminRepository;
    private readonly IStorageCloudService _storageCloudService = storageCloudService;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Handle(AdminSettingsCommand command, CancellationToken cancellationToken = default)
    {
        var validator = new AdminSettingsCommandValidator();
        var validatorValidation = validator.Validate(command);

        if (validatorValidation.IsValid)
            throw new ValidationException(validatorValidation.Errors);

        var user = await _adminRepository.GetAdminWithPhotoAsync(command.UserId, cancellationToken)
            ?? throw new NotFoundException("Пользователь не найден.");

        user.FirstName = command.Settings.FirstName;
        user.SecondName = command.Settings.SecondName;
        user.LastName = command.Settings.LastName;
        user.Gender = command.Settings.Gender;

        if (command.Settings.Photo is not null)
        {

        }

        if (command.Settings.Background is not null)
        {

        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
