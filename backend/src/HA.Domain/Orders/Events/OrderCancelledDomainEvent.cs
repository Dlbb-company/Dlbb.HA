using HA.Domain.Common.Events;

namespace HA.Domain.Orders.Events;

/// <summary>
/// Событие отмены заказа.
/// </summary>
/// <param name="Order">Заказ.</param>
public record OrderCancelledDomainEvent(Order Order) : IDomainEvent;
