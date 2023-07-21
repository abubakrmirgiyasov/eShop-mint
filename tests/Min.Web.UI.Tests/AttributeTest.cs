//using Mint.WebApp.Attributes;

//namespace Min.Web.UI.Tests;

//public class AttributeTest
//{
//    [Fact]
//    public void Check_Authorize_Attribute_For_Multiple()
//    {
//        // Arrange
//        var attributes = (IList<AttributeUsageAttribute>)typeof(AuthorizeAttribute).GetCustomAttributes(typeof(AttributeUsageAttribute), false);

//        // Act
//        var attribute = attributes[0];

//        // Assert
//        Assert.Equal(1, attributes.Count);
//        Assert.True(!attribute.AllowMultiple);
//    }

//    [Fact]
//    public void Check_AuthorizeAttribute_Role()
//    {
//        var attribute = new AuthorizeAttribute() { Roles = "ADMIN" };
        
        
//    }
//}
