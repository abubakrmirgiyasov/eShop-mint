using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace Mint.Domain.Helpers;

public class CloudinaryHelper
{
    public CloudinaryHelper(Stream stream)
    {
        var account = new Account("da3x7nugh", "617372672845596", "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d");

        var cloudinary = new Cloudinary(account);

        var x = cloudinary.CreateFolder("first_folder");

        var upload = new ImageUploadParams()
        {
            File = new FileDescription("path", stream),
            PublicId = "tes_id",
        };

        cloudinary.Upload(upload);
    }
}
