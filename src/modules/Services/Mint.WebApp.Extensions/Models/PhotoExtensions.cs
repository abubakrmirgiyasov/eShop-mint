namespace Mint.WebApp.Extensions.Models;

public static class PhotoExtensions
{
    /// <summary>
    /// Возвращает название фото для производителя
    /// </summary>
    /// <param name="name">Название</param>
    /// <param name="id">Идентификатор</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public static string GeneratePhotoName(this string name, Guid id)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentNullException(nameof(name), "Название не можем быть пустым.");
        if (id == Guid.Empty)
            throw new ArgumentException("Поле Id не может быть пустым.", nameof(id));

        return $"{id}_{name}";
    }
}
