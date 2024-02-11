namespace HA.Domain.Orders.ValueObjects;

/// <summary>
/// Адрес.
/// </summary>
/// <param name="City">Город.</param>
/// <param name="Street">Улица.</param>
/// <param name="BuildingNumber">Номер строения.</param>
/// <param name="House">Номер дома.</param>
/// <param name="HouseNumberLetter">Буква номера дома.</param>
/// <param name="Flat">Квартира.</param>
public record Address(
    string City,
    string Street,
    int? BuildingNumber,
    int House,
    char? HouseNumberLetter,
    int? Flat);
