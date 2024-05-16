using FluentValidation;
using Mint.WebApp.Admin.Identity.Application.Operations.Commands;

namespace Mint.WebApp.Admin.Identity.Application.Operations.Validations;

public sealed class AdminSettingsCommandValidator
    : AbstractValidator<SetConsumerInfoCommand>
{
    public AdminSettingsCommandValidator()
    {
        RuleFor(x => x.Settings.FirstName).NotNull().NotEmpty();
        RuleFor(x => x.Settings.SecondName).NotNull().NotEmpty();
        RuleFor(x => x.Settings.LastName).NotEmpty();
        RuleFor(x => x.Settings.Gender).IsInEnum();
    }
}
