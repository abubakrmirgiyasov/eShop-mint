using FluentValidation;
using Mint.Domain.Common;
using Mint.WebApp.Admin.Application.Operations.Commands.Manufactures;

namespace Mint.WebApp.Admin.Application.Operations.Validations.Manufactures;

internal sealed class UpdateManufactureContactsCommandValidation : AbstractValidator<UpdateManufactureContactsCommand>
{
    public UpdateManufactureContactsCommandValidation()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Contacts)
            .NotNull()
            .NotEmpty()
            .ForEach(x =>
            {
                x.ChildRules(c =>
                {
                    c.RuleFor(r => r.Type).IsInEnum();
                    c.RuleFor(x => x.ContactInformation)
                        .EmailAddress()
                        .When(x => Enum.Parse<ContactType>(x.ContactInformation) == ContactType.Email, ApplyConditionTo.CurrentValidator)
                        .Matches("^\\+\\d{10,14}$")
                        .When(x => Enum.Parse<ContactType>(x.ContactInformation) == ContactType.Phone, ApplyConditionTo.CurrentValidator);
                });
            });
    }
}
