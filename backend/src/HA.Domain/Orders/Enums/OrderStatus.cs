namespace HA.Domain.Orders.Enums;

/// <summary>
/// Статус заказа.
/// </summary>
public enum OrderStatus
{
    /// <summary>
    /// Не обработан.
    /// </summary>
    Unprocessed = 0,

    /// <summary>
    /// Подтвержден.
    /// </summary>
    Confirmed = 1,

    /// <summary>
    /// Отменен.
    /// </summary>
    Canceled = 2,

    /// <summary>
    /// Завершен.
    /// </summary>
    Completed = 3
}
