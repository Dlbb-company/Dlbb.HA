namespace HA.Domain.Orders.ValueObjects;

/// <summary>
/// Месторасположение.
/// </summary>
/// <param name="Address">Адрес.</param>
/// <param name="Name">Название ресторана, кафе, заведения и т.д.</param>
public record Place(Address Address, string Name);