using FluentValidation;
using Mint.Application.Interfaces;
using Mint.Domain.Exceptions;
using Mint.WebApp.Admin.Application.Operations.Repositories;
using Mint.WebApp.Admin.Identity.Application.Operations.Dtos;
using Mint.WebApp.Admin.Identity.Application.Operations.Validations;

namespace Mint.WebApp.Admin.Identity.Application.Operations.Commands;

public sealed record SetConsumerInfoCommand(
    Guid UserId,
    AdminSettingsBindingModel Settings
) : ICommand;

internal sealed class SetConsumerInfoCommandHandler(
    IAdminRepository adminRepository,
    IStorageCloudService storageCloudService,
    IUnitOfWork unitOfWork
) : ICommandHandler<SetConsumerInfoCommand>
{
    private readonly IAdminRepository _adminRepository = adminRepository;
    private readonly IStorageCloudService _storageCloudService = storageCloudService;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Handle(SetConsumerInfoCommand command, CancellationToken cancellationToken = default)
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
