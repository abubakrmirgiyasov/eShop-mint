using Mint.Application.Interfaces;
using Mint.Domain.Models.Admin.Products;
using Mint.WebApp.Admin.Application.Operations.Commands.Products;
using Mint.WebApp.Admin.Application.Operations.Dtos.Products;
using Mint.WebApp.Admin.Application.Operations.Repositories;

namespace Mint.WebApp.Admin.Tests.Admin.Application.Operations.Commands.Products;

public class CreateProductInfoCommandTests
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    private readonly CreateInfoProductCommandHandler _handler;

    public CreateProductInfoCommandTests()
    {
        var fixture = new Fixture().WithAutoNSubstitutions();

        _productRepository = fixture.Freeze<IProductRepository>();
        _unitOfWork = fixture.Freeze<IUnitOfWork>();

        _handler = fixture.Create<CreateInfoProductCommandHandler>();
    }

    [Fact]
    public async Task ValidationFailed_ShouldThrow()
    {
        // Arrange
        var command = new CreateInfoProductCommand(
            new ProductInfoBindingModel
            {
                FullDescription = string.Empty,
                LongName = string.Empty,
                ProductType = string.Empty,
                ShortDescription = string.Empty,
                ShortName = string.Empty,
                Sku = string.Empty
            }
        );

        // Act
        var action = () => _handler.Handle(command, default);

        // Assert
        await action.Should().ThrowAsync<ValidationException>();
    }

    [Fact]
    public async Task CreateValidProduct_ShouldWork()
    {
        // Arrange
        var fixture = new Fixture();
        var request = fixture.Create<ProductInfoBindingModel>();
        var command = new CreateInfoProductCommand(request);

        Product product = default!;
        _productRepository
            .When(x => x.AddAsync(Arg.Any<Product>()))
            .Do(x => product = x.Arg<Product>());

        // Act
        await _handler.Handle(command, default);

        // Assert
        _ = _productRepository
            .Received()
            .AddAsync(product);

        _ = _unitOfWork
            .Received()
            .SaveChangesAsync();

        using (new AssertionScope())
        {
            product.Type.Should().Be(request.ProductType);
            product.ShortName.Should().Be(request.ShortName);
            product.LongName.Should().Be(request.LongName);
            product.FullDescription.Should().Be(request.FullDescription);
            product.Sku.Should().Be(request.Sku);
            product.ShortDescription.Should().Be(request.ShortDescription);
            product.Gtin.Should().Be(request.Gtin);
            product.StoreId.Should().Be(request.Store);
            product.AdminComment.Should().Be(request.AdminComment);
        }
    }
}
