using Microsoft.AspNetCore.Mvc;
using Min.Web.UI.Tests.Constants;
using Mint.Domain.BindingModels;
using Mint.Domain.Models;
using Mint.Infrastructure.Repositories.Interfaces;
using Mint.WebApp.Attributes;
using Mint.WebApp.Controllers;
using Moq;
using System.Net;

namespace Min.Web.UI.Tests;

public class AuthenticationTest
{
    [Fact]
    public void Sign_In_Error_Check()
    {
        // Data
        var response = AuthenticationResponseConstants.GetAuthenticationResponse();
        var user = new UserSigninBindingModel() { Email = "test@m.com", Password = "test" };

        // Arrange
        var mock = new Mock<IAuthenticationRepository>();
        mock.Setup(x => x.Signin(user, "127.0.0.1")).Returns(response);
        var service = new AuthenticationController(mock.Object);

        // Act
        var result = service.Signin(user) as ObjectResult;
        var actualResult = result?.Value;

        // Assert
        Assert.Equal(response.FirstName, ((AuthenticationResponse)actualResult!).FirstName);
        Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result?.StatusCode!);
        //Assert.Equal(typeof(AuthorizeAttribute), actualResult[])
    }
}