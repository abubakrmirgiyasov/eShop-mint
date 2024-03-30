using FluentValidation;
using Mint.WebApp.Admin.Application.Operations.Dtos.Products;

namespace Mint.WebApp.Admin.Application.Operations.Validations.Products;

public sealed class ProductInfoValidator : AbstractValidator<ProductInfoBindingModel>
{
    public ProductInfoValidator()
    {
        
    }
}
