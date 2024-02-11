namespace HA.Domain.Common.Entites;

/// <summary>
/// Софт удаление.
/// </summary>
public interface ISoftDeleted
{
    /// <summary>
    /// Дата удаления.
    /// </summary>
    public DateTime? DeletedDate { get; set; }

    /// <summary>
    /// Удалена.
    /// </summary>
    public bool IsDeleted { get; set; }
}
