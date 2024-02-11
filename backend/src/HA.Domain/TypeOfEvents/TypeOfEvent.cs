using HA.Domain.Common.Entites;
using HA.Domain.Common.ValueObjects;

namespace HA.Domain.TypeOfEvents;

/// <summary>
/// Тип мероприятия.
/// </summary>
public class TypeOfEvent : Entity
{
    private TypeOfEvent()
    { }

    public TypeOfEvent(string name, Money pricePerHour)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Название не указано");

        if(pricePerHour is null)
            throw new ArgumentException("Цена в час не указана");

        Name = name;
        PricePerHour = pricePerHour;
    }

    /// <summary>
    /// Название.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Цена в час.
    /// </summary>
    public Money PricePerHour { get; set; } = null!;
}
