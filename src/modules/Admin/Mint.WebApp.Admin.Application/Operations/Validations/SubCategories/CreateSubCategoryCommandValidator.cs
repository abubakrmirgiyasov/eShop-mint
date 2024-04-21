using FluentValidation;
using Mint.WebApp.Admin.Application.Operations.Dtos.SubCategories;

namespace Mint.WebApp.Admin.Application.Operations.Validations.SubCategories;

public sealed class CreateSubCategoryCommandValidator : AbstractValidator<SubCategoryInfoBindingModel>
{
    public CreateSubCategoryCommandValidator()
    {
        RuleFor(x => x.DisplayOrder).GreaterThan(0);
        RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(100);
        RuleFor(x => x.FullName).NotEmpty().MaximumLength(400);
        RuleFor(x => x.DefaultLink).NotNull().NotEmpty().MaximumLength(60);
        RuleFor(x => x.Category).NotNull()
            .ChildRules(x => x.RuleFor(y => y.Value).NotEmpty());
    }
}
