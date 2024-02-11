using HA.Domain.Common.Events;

namespace HA.Domain.Common.Entites;

/// <summary>
/// Сущность.
/// </summary>
public abstract class Entity
{
    private List<IDomainEvent> _domainEvents = [];

    /// <summary>
    /// Идентификатор.
    /// </summary>
    public Guid Id { get; private init; }

    /// <summary>
    /// События.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    /// <summary>
    /// Добавить событие.
    /// </summary>
    /// <param name="event">Событие.</param>
    public void AddDomainEvent(IDomainEvent @event)
        => _domainEvents.Add(@event);

    /// <summary>
    /// Удалить событие.
    /// </summary>
    /// <param name="event">Событие.</param>
    public void RemoveDomainEvent(IDomainEvent @event)
        => _domainEvents?.Remove(@event);

    /// <summary>
    /// Очистить события.
    /// </summary>
    public void ClearDomainEvents()
        => _domainEvents?.Clear();
}
