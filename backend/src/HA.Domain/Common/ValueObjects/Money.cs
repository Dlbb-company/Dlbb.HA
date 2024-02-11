namespace HA.Domain.Common.ValueObjects;

/// <summary>
/// Деньги.
/// </summary>
public record Money
{
    public Money(decimal value)
    {
        if (value <= 0)
            throw new ArgumentException("Значение не может быть меньше нуля");

        Value = value;
    }

    /// <summary>
    /// Значение.
    /// </summary>
    public decimal Value { get; init; }
}
