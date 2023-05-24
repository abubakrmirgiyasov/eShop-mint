using Mint.Domain.Models;

namespace Mint.Domain.Common;

internal static class CommonExtensions
{
    internal static string GetImage64(this Photo? photo)
    {
        byte[]? bytes;

        if (photo != null && File.Exists(photo?.FilePath))
            bytes = File.ReadAllBytes(photo.FilePath);
        else
            bytes = File.ReadAllBytes("default-image.png");

        return "data:image/*;base64," + Convert.ToBase64String(bytes);
    }
}
