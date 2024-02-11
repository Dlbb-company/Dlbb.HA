using MediatR;

namespace HA.Domain.Common.Events;

/// <summary>
/// Событие домена.
/// </summary>
public interface IDomainEvent : INotification
{ }
