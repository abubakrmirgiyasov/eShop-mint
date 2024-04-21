using FluentValidation;
using Mint.WebApp.Admin.Application.Operations.Dtos.Categories;

namespace Mint.WebApp.Admin.Application.Operations.Validations.Categories;

internal sealed class CreateCategoryCommandValidation 
    : AbstractValidator<CategoryInfoBindingModel>
{
    public CreateCategoryCommandValidation()
    {
        RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(100).MinimumLength(3);
        RuleFor(x => x.DisplayOrder).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Ico).NotEmpty().MaximumLength(60);
        RuleFor(x => x.BadgeText).MaximumLength(30);
        RuleFor(x => x.BadgeStyle).MaximumLength(60);
        RuleFor(x => x.Description).MaximumLength(800);

        RuleFor(x => x.DefaultLink).MaximumLength(60);
    }
}
