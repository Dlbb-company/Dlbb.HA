using HA.Domain.Common.Events;

namespace HA.Domain.Orders.Events;

/// <summary>
/// Событие завершения заказа.
/// </summary>
/// <param name="Order">Заказ.</param>
public record OrderCompletedDomainEvent(Order Order) : IDomainEvent;