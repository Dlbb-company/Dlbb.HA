namespace HA.Domain.Common.Entites;

/// <summary>
/// Аудит
/// </summary>
public interface IAudited
{
    /// <summary>
    /// Дата создания.
    /// </summary>
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// Дата последнего изменения.
    /// </summary>
    public DateTime? LastModifiedDate { get; set; }
}
