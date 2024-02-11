namespace HA.Domain.Common.ValueObjects;

/// <summary>
/// Временной период.
/// </summary>
public record TimePeriod
{
    public TimePeriod(DateTime startDate) 
        : this (startDate, null)
    { }


    public TimePeriod(DateTime startDate, DateTime? endDate)
    {
        StartDate = startDate;
        EndDate = endDate;
    }

    /// <summary>
    /// Дата начала.
    /// </summary>
    public DateTime StartDate { get; private set; }

    /// <summary>
    /// Дата окончания.
    /// </summary>
    public DateTime? EndDate { get; private set; }
}
