using FluentValidation;
using Mint.WebApp.Admin.Application.Operations.Dtos.Products;

namespace Mint.WebApp.Admin.Application.Operations.Validations.Products;

internal sealed class CreateProductInfoCommandValidation : AbstractValidator<ProductInfoBindingModel>
{
    public CreateProductInfoCommandValidation()
    {
        RuleFor(x => x.ShowOnHomePage).NotNull();
        RuleFor(x => x.IsPublished).NotNull();
        RuleFor(x => x.ShortName).NotNull().NotEmpty().MaximumLength(255);
        RuleFor(x => x.LongName).NotNull().NotEmpty().MaximumLength(450);
        RuleFor(x => x.Sku).NotNull().NotEmpty();
        When(x => x.Gtin != null, () => RuleFor(x => x.Gtin).NotNull().NotEmpty());
        RuleFor(x => x.ShortDescription).NotNull().NotEmpty().MaximumLength(800);
        RuleFor(x => x.FullDescription).NotNull().NotEmpty().MaximumLength(4000);
        RuleFor(x => x.AdminComment).NotEmpty().MaximumLength(255);
        RuleFor(x => x.Store).NotNull().NotEmpty();
    }
}
