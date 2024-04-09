using FluentValidation;
using Mint.WebApp.Admin.Application.Operations.Dtos.Manufactures;

namespace Mint.WebApp.Admin.Application.Operations.Validations.Manufactures;

internal sealed class CreateManufactureCommandValidation : AbstractValidator<ManufactureFullBindingModel>
{
    public CreateManufactureCommandValidation()
    {
        RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(100).MinimumLength(2);
        RuleFor(x => x.DisplayOrder).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Country).NotNull().NotEmpty().MaximumLength(100).MinimumLength(2);
        RuleFor(x => x.FullAddress).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Description).NotEmpty().MaximumLength(800);
        RuleFor(x => x.Website).NotEmpty().MaximumLength(100);
    }
}
