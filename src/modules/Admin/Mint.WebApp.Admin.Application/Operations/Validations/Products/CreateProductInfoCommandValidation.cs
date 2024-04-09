using FluentValidation;
using Mint.WebApp.Admin.Application.Operations.Dtos.Products;

namespace Mint.WebApp.Admin.Application.Operations.Validations.Products;

internal sealed class CreateProductInfoCommandValidation : AbstractValidator<ProductInfoBindingModel>
{
    public CreateProductInfoCommandValidation()
    {
        
    }
}
