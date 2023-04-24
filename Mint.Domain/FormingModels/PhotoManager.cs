using Microsoft.AspNetCore.Http;
using Mint.Domain.Common;
using Mint.Domain.Models;

namespace Mint.Domain.FormingModels;

public class PhotoManager
{
    public static async Task<Photo> CopyPhotoAsync(IFormFile file, Guid id, string type = "none")
    {
        try
        {
            var photo = new Photo();
            if (!Directory.Exists($"{Constants.IMAGE_PATH}/{type}"))
                Directory.CreateDirectory($"{Constants.IMAGE_PATH}/{type}");

            string fullPath = $"{Constants.IMAGE_PATH}/{type}";

            using var fs = new FileStream($"{fullPath}/{id + file.FileName}", FileMode.Create);
            await file.CopyToAsync(fs);

            photo.FileName = Path.GetFileNameWithoutExtension(file.Name);
            photo.FileExtension = Path.GetExtension(file.FileName);
            photo.FileSize = file.Length;
            photo.FilePath = $"{fullPath}/{id + file.FileName}";
            photo.FileType = type;
            return photo;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
    
    public static void DeletePhoto(string? name)
    {
        try
        {
            if (string.IsNullOrEmpty(name))
                return;

            if (File.Exists(name))
                File.Delete(name);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
