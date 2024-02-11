using HA.Domain.Common.Events;

namespace HA.Domain.Orders.Events;

/// <summary>
/// Событие подтверждения заказа.
/// </summary>
/// <param name="Order">Заказ.</param>
public record OrderConfirmedDomainEvent(Order Order) : IDomainEvent;
