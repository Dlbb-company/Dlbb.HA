namespace HA.Domain.Feedbacks.ValueObjects;

/// <summary>
/// Оценка.
/// </summary>
public record Rating
{
    public Rating(int value)
    {
        if(value <= 0 && value > 5)
            throw new ArgumentException("Оценка не может быть меньше 1 или больше 5");

        Value = value;
    }

    /// <summary>
    /// Значение.
    /// </summary>
    public int Value { get; private set; }
}
