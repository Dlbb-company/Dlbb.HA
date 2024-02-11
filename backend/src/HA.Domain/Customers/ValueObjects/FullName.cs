namespace HA.Domain.Customers.ValueObjects;

/// <summary>
/// ФИО.
/// </summary>
/// <param name="Name">Имя.</param>
/// <param name="Surname">Фамилия.</param>
/// <param name="Patronymic">Отчество.</param>
public record FullName(string Name, string Surname, string? Patronymic);