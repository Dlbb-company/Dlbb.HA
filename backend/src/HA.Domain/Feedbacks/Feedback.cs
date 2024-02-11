using HA.Domain.Common.Entites;
using HA.Domain.Feedbacks.ValueObjects;

namespace HA.Domain.Feedbacks;

/// <summary>
/// Отзыв.
/// </summary>
public class Feedback : Entity
{
    public Feedback(string? text, Rating rating)
    {
        Text = text;
        Rating = rating;
        PostedDate = DateTime.UtcNow;
    }

    /// <summary>
    /// Текст.
    /// </summary>
    public string? Text { get; private set; }

    /// <summary>
    /// Оценка.
    /// </summary>
    public Rating Rating { get; private set; } = null!;

    /// <summary>
    /// Дата опубликования.
    /// </summary>
    public DateTime PostedDate { get; private set; }
}
