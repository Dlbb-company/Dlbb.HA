using HA.Domain.Common.Entites;
using HA.Domain.Customers.ValueObjects;

namespace HA.Domain.Customers;

/// <summary>
/// Заказчик.
/// </summary>
public class Customer : Entity
{
    private Customer()
    { }

    public Customer(FullName fullName,PhoneNumber phoneNumber)
    {
        FullName = fullName;
        PhoneNumber = phoneNumber;
    }

    /// <summary>
    /// ФИО.
    /// </summary>
    public FullName FullName { get; private set; } = null!;

    /// <summary>
    /// Номер телефона.
    /// </summary>
    public PhoneNumber PhoneNumber { get; private set; } = null!;
}
