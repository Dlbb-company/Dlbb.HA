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
