namespace Mint.Domain.Helpers;

public static class PhotoHelper
{
    public static string GetImage64(string? path)
    {
        byte[]? bytes;

        if (path != null && File.Exists(path))
            bytes = File.ReadAllBytes(path);
        else
            bytes = File.ReadAllBytes("default-image.png");

        return "data:image/*;base64," + Convert.ToBase64String(bytes);
    }
}
