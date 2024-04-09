using FluentValidation;
using Mint.WebApp.Admin.Identity.Operations.Commands.Admins;

namespace Mint.WebApp.Admin.Identity.Operations.Validations.Admins;

public sealed class AdminSettingsCommandValidator
    : AbstractValidator<AdminSettingsCommand>
{
    public AdminSettingsCommandValidator()
    {
        RuleFor(x => x.Settings.FirstName).NotNull().NotEmpty();
        RuleFor(x => x.Settings.SecondName).NotNull().NotEmpty();
        RuleFor(x => x.Settings.LastName).NotEmpty();
        RuleFor(x => x.Settings.Gender).IsInEnum();
    }
}
