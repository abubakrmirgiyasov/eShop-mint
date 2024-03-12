using Microsoft.EntityFrameworkCore;
using Mint.Domain.Exceptions;
using Mint.Domain.Models.Admin.Manufactures;
using Mint.Infrastructure.MessageBrokers.Interfaces;
using Mint.WebApp.Admin.Operations.Dtos.Manufactures;
using Mint.WebApp.Admin.Repositories.Interfaces;

namespace Mint.WebApp.Admin.Operations.Commands.Manufactures;

public sealed record UpdateManufactureContactsCommand(Guid Id, List<ManufactureContactDto> Contacts) : ICommand;

internal sealed class UpdateManufactureContactsCommandHandler(
    IManufactureRepository manufactureRepository,
    ILogger<UpdateManufactureContactsCommandHandler> logger
) : ICommandHandler<UpdateManufactureContactsCommand>
{
    private readonly IManufactureRepository _manufactureRepository = manufactureRepository;
    private readonly ILogger<UpdateManufactureContactsCommandHandler> _logger = logger;

    public async Task Handle(UpdateManufactureContactsCommand request, CancellationToken cancellationToken)
    {
        var manufacture = await _manufactureRepository
            .Context
            .Manufactures
            .Include(x => x.Contacts)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
            ?? throw new NotFoundException($"Производитель c Id={request.Id} не найден.");

        manufacture.Contacts.Clear();

        foreach (var contact in request.Contacts)
        {
            manufacture.Contacts.Add(new ManufactureContact
            {
                Id = Guid.NewGuid(),
                Type = contact.Type,
                ContactInformation = contact.ContactInformation,
                UpdateDateTime = DateTimeOffset.Now
            });
        }

        await _manufactureRepository.Context.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Обновлены контакты производителя! Id={Id}", manufacture.Id);
    }
}