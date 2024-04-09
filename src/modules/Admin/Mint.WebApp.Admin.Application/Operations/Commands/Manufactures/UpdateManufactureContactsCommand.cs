using FluentValidation;
using Microsoft.Extensions.Logging;
using Mint.Application.Interfaces;
using Mint.Domain.Exceptions;
using Mint.Domain.Models.Admin.Manufactures;
using Mint.WebApp.Admin.Application.Operations.Dtos.Manufactures;
using Mint.WebApp.Admin.Application.Operations.Repositories;
using Mint.WebApp.Admin.Application.Operations.Validations.Manufactures;

namespace Mint.WebApp.Admin.Application.Operations.Commands.Manufactures;

public sealed record UpdateManufactureContactsCommand(Guid Id, List<ManufactureContactDto> Contacts) : ICommand;

internal sealed class UpdateManufactureContactsCommandHandler(
    IManufactureRepository manufactureRepository,
    IUnitOfWork unitOfWork,
    ILogger<UpdateManufactureContactsCommandHandler> logger
) : ICommandHandler<UpdateManufactureContactsCommand>
{
    private readonly IManufactureRepository _manufactureRepository = manufactureRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ILogger<UpdateManufactureContactsCommandHandler> _logger = logger;

    public async Task Handle(UpdateManufactureContactsCommand request, CancellationToken cancellationToken)
    {
        var manufacture = await _manufactureRepository.GetManufactureWithContacts(request.Id, cancellationToken)
            ?? throw new NotFoundException($"Производитель c Id={request.Id} не найден.");

        var validation = new UpdateManufactureContactsCommandValidation();
        var validationValidator = validation.Validate(request);

        if (!validationValidator.IsValid)
            throw new ValidationException(validationValidator.Errors);

        manufacture.Contacts.Clear();

        foreach (var contact in request.Contacts)
        {
            manufacture.Contacts.Add(
                new ManufactureContact
                {
                    Id = Guid.NewGuid(),
                    Type = contact.Type,
                    ContactInformation = contact.ContactInformation,
                    UpdateDateTime = DateTimeOffset.Now
                }
            );
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Обновлены контакты производителя! Id={Id}", manufacture.Id);
    }
}