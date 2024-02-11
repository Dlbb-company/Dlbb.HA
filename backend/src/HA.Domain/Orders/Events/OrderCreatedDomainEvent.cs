using HA.Domain.Common.Events;

namespace HA.Domain.Orders.Events;

/// <summary>
/// Событие создания заказа.
/// </summary>
/// <param name="Order">Заказ.</param>
/// <param name="CustomerId">Идентификатор заказчика.</param>
public record OrderCreatedDomainEvent(Order Order, Guid CustomerId): IDomainEvent;
