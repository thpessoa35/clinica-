
namespace HospitalSolution.Domain.Entities.Address.Entities;

public sealed class PacientAddress
{
    public string? Id { get; set; }
    public string Address { get; private set; } = string.Empty;
    public string City { get; private set; } = string.Empty;
    public string State { get; private set; } = string.Empty;
    public string ZipCode { get; private set; } = string.Empty;
    public int Number { get; private set; } 

    public PacientAddress() { }


    private PacientAddress(string address, string city, string state, string zipCode, int number)
    {
        AddressSet(address);
        CitySet(city);
        StateSet(state);
        ZipCodeSet(zipCode);
        NumberSet(number);
    }

    public static PacientAddress Create(string address, string city, string state, string zipCode, int number)
    {
        return new(address, city, state, zipCode, number);
    }

    public void Put(string? address, string? city, string? state, string? zipCode, int number)
    {
        AddressSet(address);
        CitySet(city);
        StateSet(state);
        ZipCodeSet(zipCode);
        NumberSet(number);
    }


    internal void AddressSet(string address)
    {
        Address = address;
        if (string.IsNullOrEmpty(Address))
        {
            throw new ArgumentNullException("address cannot be null or empty");
        }
    }

    internal void CitySet(string city)
    {
        City = city;
        if (string.IsNullOrEmpty(city))
        {
            throw new ArgumentNullException("city cannot be null or empty");
        }
    }
    internal void StateSet(string state)
    {
        State = state;
        if (string.IsNullOrEmpty(state))
        {
            throw new ArgumentNullException("state cannot be null or empty");
        }
    }
    internal void ZipCodeSet(string zipCode)
    {
        ZipCode = zipCode;
        if (string.IsNullOrEmpty(zipCode))
        {
            throw new ArgumentNullException("zipCode cannot be null or empty");
        }
    }
    internal void NumberSet(int number)
    {
        Number = number;
        if (number <= 0)
        {
            throw new ArgumentNullException("number cannot be null or empty");
        }
    }
}