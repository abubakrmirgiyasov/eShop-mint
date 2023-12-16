using FluentValidation;
using Mint.Domain.Common;
using Mint.Domain.DTO_s.Identity;

namespace Mint.WebApp.Admin.Identity.Commands.Validations;

public class SignInCommandValidation : AbstractValidator<SignInRequest>
{
    public SignInCommandValidation()
    {
        RuleFor(x => x.Type).IsInEnum();
        RuleFor(x => x.Login)
            .EmailAddress()
            .When(x => x.Type == ContactType.Email, ApplyConditionTo.CurrentValidator)
            .Matches("^\\+\\d{10,14}$")
            .When(x => x.Type == ContactType.Phone, ApplyConditionTo.CurrentValidator);
    }
}
