using FluentValidation;
using Mint.WebApp.Admin.Identity.Commands.Admins;

namespace Mint.WebApp.Admin.Identity.Commands.Validations.Admins;

public sealed class AdminSettingsCommandValidator
    : AbstractValidator<AdminSettingsCommand>
{
    public AdminSettingsCommandValidator()
    {
        RuleFor(x => x.Settings.FirstName).NotEmpty();
        RuleFor(x => x.Settings.SecondName).NotEmpty();
        RuleFor(x => x.Settings.LastName).NotEmpty();
        RuleFor(x => x.Settings.Gender).GreaterThanOrEqualTo(0);
    }
}
