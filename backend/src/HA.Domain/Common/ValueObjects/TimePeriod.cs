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
        if (endDate is not null && startDate <= endDate)
            throw new ArgumentException("Невалидные временной период");

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
