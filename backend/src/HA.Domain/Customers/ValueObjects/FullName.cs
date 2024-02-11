namespace HA.Domain.Customers.ValueObjects;

/// <summary>
/// ФИО.
/// </summary>
public record FullName 
{
    public FullName(string name, string surname, string? patronymic)
    {
        var hasEmptyArgument = string.IsNullOrWhiteSpace(name) ||
            string.IsNullOrWhiteSpace(surname) ||
            string.IsNullOrWhiteSpace(patronymic);

        if (hasEmptyArgument)
            throw new ArgumentException("Невалидные значения ФИО");

        Name = name;
        Surname = surname;
        Patronymic = patronymic;
    }

    /// <summary>
    /// Имя.
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Фамилия.
    /// </summary>
    public string Surname { get; init; }

    /// <summary>
    /// Отчество.
    /// </summary>
    public string? Patronymic { get; init; }
}