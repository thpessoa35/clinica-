using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using addressId;
using addressValidate;
using HospitalSolution.Domain.Models;

namespace addressesEmploye;

public class Addresses : Entity<AddressId>
{
    public string Id { get; set; }
    public string Address { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string ZipCode { get; private set; }
    public int Number { get; private set; }
    public string? Idemployee { get; set; }

    public Addresses():base(default){}
    private Addresses(AddressId id, string address, string city, string state, string zipCode, int number) : base(id)
    {
        AddressSet(address);
        CitySet(city);
        StateSet(state);
        ZipCodeSet(zipCode);
        NumberSet(number);
    }

    private Addresses(AddressId id) : base(id)
    {

    }

    public static Addresses Create(string address, string city, string state, string zipCode, int number)
    {
        return new(AddressId.CreateUnique(), address, city, state, zipCode, number);
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

}
