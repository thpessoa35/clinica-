

namespace addressValidate;

public static class AddressValidate
{
    internal static void IsAddressNotNull(string address)
    {
        if (string.IsNullOrEmpty(address))
        {
            throw new ArgumentException("Address cannot be null or empty");
        }
    }
    internal static void IsCityNotNull(string city)
    {
        if (string.IsNullOrEmpty(city))
        {
            throw new ArgumentException("City cannot be null or empty");
        }
    }
    internal static void IsStateNotNull(string state)
    {
        if (string.IsNullOrEmpty(state))
        {
            throw new ArgumentException("State cannot be null or empty");
        }
    }
    internal static void IsZipCodeNotNull(string zipCode)
    {
        if (string.IsNullOrEmpty(zipCode))
        {
            throw new ArgumentException("ZipCode cannot be null or empty");
        }
    }
    internal static void IsNumberNotNull(int number){
        if (number.ToString() == ""){
            throw new ArgumentException("Number cannot be null or empty");
        }
    }
}