using System.Text.RegularExpressions;

namespace HA.Domain.Customers.ValueObjects;

/// <summary>
/// Номер телефона.
/// </summary>
public partial record PhoneNumber
{
    private const string ValidNumberRegexPattern = @"^\d{7,15}$";
    private const string ValidCountryCodeRegexPattern = @"^[A-Za-z]{2}$";

    public PhoneNumber(string number, string countryCode)
    {
        if (!IsValidNumber(number))
            throw new ArgumentException("Неверный номер");

        if (!IsValidCountryCode(countryCode))
            throw new ArgumentException("Неверный код страны");

        Number = number;
        CountryCode = countryCode;
    }

    /// <summary>
    /// Номер.
    /// </summary>
    public string Number { get; init; }

    /// <summary>
    /// Код страны.
    /// </summary>
    public string CountryCode { get; init;  }

    private static bool IsValidNumber(string number)
    {
        return !string.IsNullOrWhiteSpace(number) && NumberRegex().IsMatch(number);
    }

    private static bool IsValidCountryCode(string countryCode)
    {
        return !string.IsNullOrWhiteSpace(countryCode) && CountryCodeRegex().IsMatch(countryCode);
    }

    [GeneratedRegex(ValidCountryCodeRegexPattern)]
    private static partial Regex CountryCodeRegex();

    [GeneratedRegex(ValidNumberRegexPattern)]
    private static partial Regex NumberRegex();
}
