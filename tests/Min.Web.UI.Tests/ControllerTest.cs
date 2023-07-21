//using Microsoft.AspNetCore.Mvc;
//using Min.Web.UI.Tests.Constants;
//using Mint.Domain.Models;
//using Mint.Infrastructure.Repositories.Interfaces;
//using Mint.WebApp.Controllers;
//using Moq;

//namespace Min.Web.UI.Tests;

//public class ControllerTest
//{
//    [Fact]
//    public void GetUserByIdReturnsSingleUser()
//    {
//        // Arrange
//        var id = Guid.Parse("bf0df96c-72cb-498e-9339-6e036f79bbb4");
//        var mock = new Mock<IUserRepository>();
//        mock.Setup(x => x.GetUserById(id)).Returns(new UserConstants().User);
//        var controller = new UserController(mock.Object);

//        // Act
//        var result = controller.GetUserById(id);

//        // Assert
//        var viewResult = Assert.IsType<OkObjectResult>(result);
//        var model = Assert.IsAssignableFrom<User>(viewResult);
//        Assert.Equal(200, viewResult.StatusCode);
//    }
//}
