using FluentValidation;
using Mint.WebApp.Admin.Application.Operations.Commands.Products;

namespace Mint.WebApp.Admin.Application.Operations.Validations.Products;

internal sealed class UpdateProductPriceCommandValidator : AbstractValidator<UpdateProductPriceCommand>
{
    public UpdateProductPriceCommandValidator()
    {
        RuleFor(x => x.ProductId).NotEmpty();
        RuleFor(x => x.Product).NotNull().ChildRules(x =>
        {
            x.RuleFor(y => y.Price).GreaterThan(0);
            x.RuleFor(y => y.Delivery).NotEmpty();

            x.When(y => y.CustomerPrice,
                () => x.RuleFor(y => y.CustomerPriceMin).GreaterThan(0));
            x.When(y => y.CustomerPrice,
                () => x.RuleFor(y => y.CustomerPriceMax).GreaterThan(y => y.CustomerPriceMin));
            x.When(y => y.SpecialDate != null,
                () => x.RuleFor(y => y.SpecialDate!.From).GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now)));
            x.When(y => y.SpecialDate != null,
                () => x.RuleFor(y => y.SpecialDate!.To).GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now)));
            x.When(y => !y.IsFreeTax, 
                () => x.RuleFor(y => y.TaxPrice).GreaterThan(0));
            x.When(y => y.SpecialPrice.HasValue,
                () => x.RuleFor(y => y.SpecialPrice).GreaterThan(0));
        });
    }
}
