using HA.Domain.Common.Entites;
using HA.Domain.Orders.Enums;
using HA.Domain.Orders.Events;
using HA.Domain.Orders.ValueObjects;
using HA.Domain.TypeOfEvents;

namespace HA.Domain.Orders;

/// <summary>
/// Заказ.
/// </summary>
public class Order : Entity, IAggregateRoot
{
    private Order()
    { }

    /// <summary>
    /// Заказ.
    /// </summary>
    /// <param name="eventDate">Дата мероприятия.</param>
    /// <param name="place">Месторасположения.</param>
    public Order(Guid customerId, DateTime eventDate, Place place)
    {
        EventDate = eventDate;
        Place = place;
        Status = OrderStatus.Unprocessed;

        AddDomainEvent(new OrderCreatedDomainEvent(this, customerId));
    }

    /// <summary>
    /// Дата мероприятия.
    /// </summary>
    public DateTime EventDate { get; private set; }

    /// <summary>
    /// Месторасположения.
    /// </summary>
    public Place Place { get; private set; } = null!;

    /// <summary>
    /// Тип мероприятия.
    /// </summary>
    public TypeOfEvent TypeOfEvent { get; private set; } = null!;

    /// <summary>
    /// Гости.
    /// </summary>
    public IReadOnlyCollection<string> Guests { get; private set; } = [];

    /// <summary>
    /// План мероприятия.
    /// </summary>
    public string? EventPlan { get; private set; }

    /// <summary>
    /// Статус.
    /// </summary>
    public OrderStatus Status { get; set; }

    /// <summary>
    /// Перезаписать план мероприятия.
    /// </summary>
    /// <param name="plan">План.</param>
    public void OverwriteEventPlan(string plan) 
        => EventPlan = plan;

    /// <summary>
    /// Перезаписать гостей.
    /// </summary>
    /// <param name="guests">Гости.</param>
    public void OverwriteGuests(IEnumerable<string> guests)
        => Guests = guests.ToList();

    /// <summary>
    /// Изменить дату мероприятия.
    /// </summary>
    /// <param name="newEventDate">Новая дата мероприятия.</param>
    public void ChangeEventDate(DateTime newEventDate)
        => EventDate = newEventDate;

    /// <summary>
    /// Подтвердить.
    /// </summary>
    public void Confirm()
    {
        Status = OrderStatus.Confirmed;
        AddDomainEvent(new OrderConfirmedDomainEvent(this));
    }

    /// <summary>
    /// Отменить.
    /// </summary>
    public void Cancel()
    {
        Status = OrderStatus.Canceled;
        AddDomainEvent(new OrderCancelledDomainEvent(this));
    }

    /// <summary>
    /// Завершить.
    /// </summary>
    public void Complete()
    {
        Status = OrderStatus.Completed;
        AddDomainEvent(new OrderCompletedDomainEvent(this));
    }
}
