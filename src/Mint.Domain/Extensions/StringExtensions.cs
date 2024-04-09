namespace Mint.Domain.Extensions;

public static class StringExtensions
{
    /// <summary>
    /// Returns string with first letter upper
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public static string FirstCharToUpper(this string str)
    {
        return str switch
        {
            null => throw new ArgumentNullException(nameof(str)),
            "" => throw new ArgumentException($"{nameof(str)} cannot be empty", nameof(str)),
            _ => string.Concat(str[0].ToString().ToUpper(), str.AsSpan(1)),
        };
    }

    public static bool IsNullOrEmpty(this string str)
    {
        return str switch
        {
            null => throw new ArgumentNullException(nameof(str)),
            _ => string.IsNullOrEmpty(str)
        };
    }

    public static string ConvertToPhoneNumber(this string value)
    {
        return value;
    }

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
