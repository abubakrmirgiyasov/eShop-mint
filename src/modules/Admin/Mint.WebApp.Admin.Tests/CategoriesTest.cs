using Microsoft.AspNetCore.Mvc;
using Mint.Infrastructure.Repositories.Admin.Interfaces;
using Mint.WebApp.Admin.Controllers;
using Mint.WebApp.Admin.DTO_s.Categories;
using Mint.WebApp.Admin.Services;
using Moq;

namespace Mint.WebApp.Test;

public class CategoriesTest
{
    [Theory]
    [InlineData(null)]
    public void Get_Sample_Categories_Should_Return_Ok(List<CategorySampleViewModel> values)
    {
        // Arrange
        //var mock = new Mock<ICategoryRepository>();
        //mock.Setup(repo => repo.GetSampleCategoriesAsync()).ReturnsAsync(values);
        //var controller = new CategoryController(mock.Object);

        //// Act
        //var res = controller.GetSampleCategories();

        //// Assert
        //var viewRes = Assert.IsType<ViewResult>(res);
        //var model = Assert.IsAssignableFrom<CategorySampleViewModel>(viewRes.Model);
        //Assert.IsType(model.GetType(), values.GetType());
        //Assert.Null(model);
        //Assert.NotNull(model);
    }
}