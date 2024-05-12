
namespace medicValidate;

public static class MedicValidate
{
    private const int lengthCrmNumber = 13;
    internal static void IsNameNotNull(string firstName)
    {
        if (string.IsNullOrEmpty(firstName))
        {
            throw new ArgumentException("Firstname cannot be null or empty", nameof(firstName));
        }
    }

    internal static void IsLastNotNull(string lastName)
    {
        if (string.IsNullOrEmpty(lastName))
        {
            throw new ArgumentException("LastName cannot be null or empty", nameof(lastName));
        }
    }
    internal static void IsCrmNotNull(int crmNumber)
    {
        if (crmNumber == 0 || crmNumber > lengthCrmNumber)
        {
            throw new ArgumentException("Crm Invalid ", nameof(crmNumber));
        }
    }
    internal static void IsSpecialtyNotNull(string specialty)
    {
        if (string.IsNullOrEmpty(specialty))
        {
            throw new ArgumentException("LastName cannot be null or empty", nameof(specialty));
        }
    }
    internal static void IsPhoneNumberNotNull(string phoneNumber)
    {
        if (string.IsNullOrEmpty(phoneNumber) && phoneNumber.Length > 13)
        {
            throw new ArgumentException("LastName cannot be null or empty", nameof(phoneNumber));
        }
    }
}
