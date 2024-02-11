using HA.Domain.Common.Entites;

namespace HA.Domain.Files;

/// <summary>
/// Файл.
/// </summary>
public class File : Entity
{
    public File(string originalName, string extension)
    {
        OriginalName = originalName;
        Extension = extension;
    }

    /// <summary>
    /// Оригинальное имя.
    /// </summary>
    public string OriginalName { get; set; }

    /// <summary>
    /// Расширение.
    /// </summary>
    public string Extension { get; set; }
}
