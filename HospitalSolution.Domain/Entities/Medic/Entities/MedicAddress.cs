
using addressValidate;

public sealed class MedicAddress
{
    public string? Id { get; set; }
    public string Address { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string ZipCode { get; private set; }
    public int Number { get; private set; }
 
    public MedicAddress(){}
    private MedicAddress(string address, string city, string state, string zipCode, int number)
    {
        AddressSet(address);
        CitySet(city);
        StateSet(state);
        ZipCodeSet(zipCode);
        NumberSet(number);
    }

    public static MedicAddress Create(string address, string city, string state, string zipCode, int number)
    {
        return new(address, city, state, zipCode, number);
    }

    private void AddressSet(string address)
    {
        Address = address;
        AddressValidate.IsAddressNotNull(address);
    }
    private void CitySet(string city)
    {
        City = city;
        AddressValidate.IsCityNotNull(city);
    }
    private void StateSet(string state)
    {
        State = state;
        AddressValidate.IsStateNotNull(state);
    }
    private void ZipCodeSet(string zipCode)
    {
        ZipCode = zipCode;
        AddressValidate.IsZipCodeNotNull(zipCode);
    }
    private void NumberSet(int number)
    {
        Number = number;
        AddressValidate.IsNumberNotNull(number);
    }

    public static implicit operator List<object>(MedicAddress v)
    {
        throw new NotImplementedException();
    }

}
