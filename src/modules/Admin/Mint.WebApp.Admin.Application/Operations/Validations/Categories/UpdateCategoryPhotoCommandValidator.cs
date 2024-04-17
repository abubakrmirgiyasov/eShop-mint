using FluentValidation;
using Mint.WebApp.Admin.Application.Operations.Commands.Categories;

namespace Mint.WebApp.Admin.Application.Operations.Validations.Categories;

public sealed class UpdateCategoryPhotoCommandValidator : AbstractValidator<UpdateCategoryPhotoCommand>
{
    public UpdateCategoryPhotoCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.CategoryPhoto).NotNull().ChildRules(x =>
        {
            x.RuleFor(y => y.Photo).NotNull();
            x.RuleFor(y => y.Photo.FileName).MaximumLength(2000);
        });
    }
}
