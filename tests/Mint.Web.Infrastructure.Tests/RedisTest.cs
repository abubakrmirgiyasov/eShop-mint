using Mint.Infrastructure.Redis.Interface;
using Mint.Web.Infrastructure.Tests.Constants;
using Mint.WebApp.Admin.Operations.Dtos;
using Moq;

namespace Mint.Web.Admin.Tests;

public class RedisTest
{
    [Theory]
    [InlineData(null)]
    public void Check_Redis_Get_For_Null_Should_Be_Ok(TagFullViewModel value)
    {
        // Arrange
        var mock = new Mock<IDistributedCacheManager>();
        mock.Setup(x => x.Get<TagFullViewModel>("GET_ATTRIBUTES")).Returns(value);

        // Act
        var res = mock.Object.Get<TagFullViewModel>("GET_ATTRIBUTES");

        // Assert
        Assert.Null(res);
        Assert.Null(res?.Value);
    }

    [Fact]
    public void Set_Data_To_Redis_Should_Be_Ok()
    {
        // Arrange
        // var mock = new Mock<IDistributedCacheManager>();
        // mock.Setup(x => x.Set("SET_ATTRIBUTE", TagsData.SingleBinding));

        // Act

        // Assert
        // mock.Verify(x => x.Set("GET_ATTRIBUTES", TagsData.SingleBinding), Times.Once);
    }

    [Theory]
    [InlineData(null, false)]
    [InlineData("", false)]
    [InlineData("Key", true)]
    [InlineData("Key_2", true)]
    public void Check_For_Key_Exists_Should_Be_Ok(string key, bool value)
    {
        // Arrange
        var mock = new Mock<IDistributedCacheManager>();
        mock.Setup(x => x.Exists(key)).Returns(value);

        // Act
        var res = mock.Object.Exists(key);

        // Assert
        Assert.Equal(res, value);
    }
}