using Mint.WebApp.Admin.Operations.Dtos;

namespace Mint.Web.Infrastructure.Tests.Constants;

public class TagsData
{
    public static TagFullViewModel SingleView =>
        new ()
        {
            Label = "Test_Data",
            Value = Guid.NewGuid(),
            Translate = "Test_Data",
        };

    public static TagFullBindingModel SingleBinding =>
        new()
        {
            Label = "Test_Data",
            Value = Guid.NewGuid(),
            Translate = "Test_Data",
        };
}
