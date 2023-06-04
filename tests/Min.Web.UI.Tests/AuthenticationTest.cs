using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using Min.Web.UI.Tests.Constants;
using Min.Web.UI.Tests.Services;
using Mint.Domain.Models;
using Mint.Infrastructure.Repositories.Interfaces;
using Mint.WebApp.Controllers;
using Moq;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace Min.Web.UI.Tests;

public class AuthenticationTest
{
    private readonly TestServer _server;
    private readonly HttpClient _client;

    public AuthenticationTest()
    {
        _server = new TestServer(new WebHostBuilder()
            .UseStartup<TestStartup>());
        _client = _server.CreateClient();
    }

    [Fact]
    public void Sign_In_Error_Check()
    {
        // Data
        var response = AuthenticationResponseConstants.GetAuthenticationResponse();
        var user = new UserConstants().SigninModel;

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

    [Fact]
    public async Task Should_Expect_401_When_Login_With_Invalid_Credentials()
    {
        // https://localhost:7121/
        var response = await _client.PostAsync("api/authentication/signin",
            new StringContent(
                content: JsonSerializer.Serialize(new UserConstants().SigninFailModel),
                encoding: Encoding.UTF8,
                mediaType: MediaTypeNames.Application.Json));
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);

        //// Arrange
        //var mock = new Mock<IAuthenticationRepository>();
        //mock.Setup(x => x.Signin(new UserConstants().SigninModel, "127.0.1")).Returns(new AuthenticationResponse());
        //var controller = new AuthenticationController(mock.Object);

        //// Act
        //var result = controller.Signin(new UserConstants().SigninModel);

        //// Assert
        //var viewResult = Assert.IsType<ActionResult>(result);
        //var model = Assert.IsAssignableFrom<IEnumerable<UserSigninBindingModel>>(viewResult.ExecuteResult);
        //Assert.NotNull(model);
    }

    //[Fact]
    //public async Task Should_Return_Correct_Signin()
    //{

    //}
}