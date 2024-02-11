namespace HA.Domain.Common.Entites;

/// <summary>
/// Аудит и софт удаление.
/// </summary>
public interface IAuditedSoftDeleted : IAudited, ISoftDeleted
{ }