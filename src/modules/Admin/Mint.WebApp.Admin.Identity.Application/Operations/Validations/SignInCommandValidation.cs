using FluentValidation;
using Mint.Domain.Common;
using Mint.WebApp.Admin.Identity.Application.Operations.Dtos;

namespace Mint.WebApp.Admin.Identity.Application.Operations.Validations;

public class SignInCommandValidation : AbstractValidator<SignInRequest>
{
    public SignInCommandValidation()
    {
        RuleFor(x => Enum.Parse<ContactType>(x.Type)).IsInEnum();
        RuleFor(x => x.Login)
            .EmailAddress()
            .When(x => Enum.Parse<ContactType>(x.Type) == ContactType.Email, ApplyConditionTo.CurrentValidator)
            .Matches("^\\+\\d{10,14}$")
            .When(x => Enum.Parse<ContactType>(x.Type) == ContactType.Phone, ApplyConditionTo.CurrentValidator);
    }
}
