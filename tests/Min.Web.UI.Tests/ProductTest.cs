using Microsoft.AspNetCore.Mvc;
using Min.Web.UI.Tests.Constants;
using Mint.Infrastructure.Repositories.Interfaces;
using Mint.WebApp.Controllers;
using Moq;

namespace Min.Web.UI.Tests;

public class ProductTest
{
    [Fact]
    public void Should_Return_All_Products()
    {
        // Arrange
        var mock = new Mock<IProductRepository>();
        mock.Setup(x => x.GetProductsAsync());

        // Act
        var controller = new ProductController(mock.Object);
        var action = controller.GetProducts();
        var result = action.Result;

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void Should_Return_Products_By_Category()
    {
        // Arrange
        var mock = new Mock<IProductRepository>();
        mock.Setup(x => x.GetProductsByCategoryAsync("smartphone"));

        // Act
        var controller = new ProductController(mock.Object);
        var action = controller.GetProductsByCategory("smartphones");
        var result = action.Result;

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void Should_Return_Top_Products()
    {
        // Arrange
        var mock = new Mock<IProductRepository>();
        mock.Setup(x => x.GetTopProductsAsync(6));

        // Act
        var controller = new ProductController(mock.Object);
        var action = controller.GetTopProducts(6);
        var result = action.Result;

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void Should_Return_Top_Saled_Products()
    {
        // Arrange
        var mock = new Mock<IProductRepository>();
        mock.Setup(x => x.GetTopSaledProductsAsync(6));

        // Act
        var controller = new ProductController(mock.Object);
        var action = controller.GetTopProducts(6);
        var result = action.Result;

        // Assert
        Assert.IsType<OkObjectResult>(result);
        //Assert.True(result)
    }

    [Fact]
    public void Should_Create_New_Product()
    {
        // Arrange
        var mock = new Mock<IProductRepository>();
        mock.Setup(x => x.CreateProductAsync(ProductConstants.NewProduct()));

        // Act
        var controller = new ProductController(mock.Object);
        var action = controller.CreateProduct(ProductConstants.NewProduct());
        var result = action.Result;

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void Should_Update_Product_Info()
    {

    }

    [Fact]
    public void Should_Update_Product_Characteristic()
    {

    }

    [Fact]
    public void Should_Update_Product_Price()
    {

    }
}
