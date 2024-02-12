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
    private List<Guid> _fileIds;
    private List<string> _guests;

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
    public IReadOnlyCollection<string> Guests => _guests.AsReadOnly();

    /// <summary>
    /// План мероприятия.
    /// </summary>
    public string? EventPlan { get; private set; }

    /// <summary>
    /// Статус.
    /// </summary>
    public OrderStatus Status { get; private set; }

    /// <summary>
    /// Причина отмены.
    /// </summary>
    public string? CancelledReason { get; private set; }

    /// <summary>
    /// Идентификатор заказчика.
    /// </summary>
    public Guid CustomerId { get; private set; }

    /// <summary>
    /// Идентификатор типа мероприятия.
    /// </summary>
    public Guid TypeOfEventId { get; private set; }

    /// <summary>
    /// Чаевые.
    /// </summary>
    public Money Tips { get; private set; }

    /// <summary>
    /// Идентификаторы файлов.
    /// </summary>
    public IReadOnlyCollection<Guid> FileIds => _fileIds.AsReadOnly();

    /// <summary>
    /// Добавить файлы.
    /// </summary>
    /// <param name="fileIds">Идентификаторы файлов.</param>
    public bool AddFiles(params Guid[] fileIds)
    {
        if (Status != OrderStatus.Completed)
            return false;

        if (_fileIds.Any(fileId => fileIds.Contains(fileId)))
            return false;

        _fileIds.AddRange(fileIds);

        return true;
    }

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
        => _guests = guests.ToList();

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
}
