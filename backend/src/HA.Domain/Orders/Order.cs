using HA.Domain.Common.Entites;
using HA.Domain.Common.ValueObjects;
using HA.Domain.Orders.Enums;
using HA.Domain.Orders.Events;
using HA.Domain.Orders.ValueObjects;

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
    public Order(Guid customerId, Guid typeOfEventId, TimePeriod plannedTimePeriod, Place place)
    {
        CustomerId = customerId;
        PlannedTimePeriod = plannedTimePeriod;
        Place = place;
        TypeOfEventId = typeOfEventId;
        Status = OrderStatus.Unprocessed;

        AddDomainEvent(new OrderCreatedDomainEvent(this, customerId));
    }

    /// <summary>
    /// Планируемый временной период мероприятия.
    /// </summary>
    public TimePeriod PlannedTimePeriod { get; private set; } = null!;

    /// <summary>
    /// Фактический временной период мероприятия.
    /// </summary>
    public TimePeriod ActualTimePeriod { get; private set; } = null!;

    /// <summary>
    /// Месторасположения.
    /// </summary>
    public Place Place { get; private set; } = null!;

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
    /// Причина отмены.
    /// </summary>
    public string? CancelledReason { get; private set; }

    /// <summary>
    /// Идентификатор заказчика.
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// Идентификатор типа мероприятия.
    /// </summary>
    public Guid TypeOfEventId { get; private set; }

    /// <summary>
    /// Чаевые.
    /// </summary>
    public Money Tips { get; set; }

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
    /// Изменить временной период мероприятия.
    /// </summary>
    /// <param name="newTimePeriod">Новый временной период.</param>
    public void ChangeEventTimePeriod(TimePeriod newTimePeriod)
        => PlannedTimePeriod = newTimePeriod;

    /// <summary>
    /// Подтвердить.
    /// </summary>
    public bool Confirm()
    {
        if (Status != OrderStatus.Unprocessed)
            return false;

        Status = OrderStatus.Confirmed;
        AddDomainEvent(new OrderConfirmedDomainEvent(this));

        return true;
    }

    /// <summary>
    /// Отменить.
    /// </summary>
    public bool Cancel(string? reason)
    {
        if (Status is not OrderStatus.Unprocessed or OrderStatus.Confirmed)
            return false;

        CancelledReason = reason;
        Status = OrderStatus.Canceled;
        AddDomainEvent(new OrderCancelledDomainEvent(this));

        return true;
    }

    /// <summary>
    /// Завершить.
    /// </summary>
    public bool Complete()
    {
        if (Status != OrderStatus.Confirmed)
            return false;
        
        Status = OrderStatus.Completed;
        AddDomainEvent(new OrderCompletedDomainEvent(this));

        return true;
    }

    /// <summary>
    /// Билдер завершения заказа.
    /// </summary>
    public class CompleteOrderBuilder
    {
        private readonly Order order;

        public CompleteOrderBuilder(Order order)
        {
            if (order.Status != OrderStatus.Confirmed)
                throw new ArgumentException($"Заказ должен быть в статусе {nameof(OrderStatus.Confirmed)}");

            this.order = order;
        }

        /// <summary>
        /// С фактической датой проведения.
        /// </summary>
        /// <param name="actualTimePeriod">Фактическая дата проведения.</param>
        public CompleteOrderBuilder WithActualTimePeriod(TimePeriod actualTimePeriod)
        {
            order.ActualTimePeriod = actualTimePeriod;
            return this;
        }

        /// <summary>
        /// С чаевыми.
        /// </summary>
        /// <param name="tips">Чаевые.</param>
        public CompleteOrderBuilder WithTips(Money tips)
        {
            order.Tips = tips;
            return this;
        }

        public Order Build()
        {
            order.Complete();
            return order;
        }
    }
}
