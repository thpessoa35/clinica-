
using addressesEmploye;
using emailValidator;
using employeId;
using formatPassword;
using HospitalSolution.Domain.Entities.Employe.ValueObject;
using HospitalSolution.Domain.Models;

namespace employe;

public class Employe : AggregateRoot<EmployeId>
{

    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Password { get; private set; } = string.Empty;
    public string PhoneNumber { get; private set; } = string.Empty;
    public List<Addresses> Addresses { get; private set; } = new List<Addresses>();

    private Employe() : base(default) { }
    private Employe(EmployeId id, string firstName, string lastName, string email, string password, string phoneNumber, List<Addresses> addresses) : base(id)
    {

        FirstNameSet(firstName);
        LastNameSet(lastName);
        EmailSet(email);
        PasswordSet(password);
        PhoneNumberSet(phoneNumber);;
        AddressesSet(addresses);
    }

    public static Employe Create(string firstName, string lastName, string email, string password, string phoneNumber, List<Addresses> addresses)
    {
        return new(EmployeId.CreateUnique(), firstName, lastName, email, password, phoneNumber, addresses);
    }

    private void FirstNameSet(string firstName)
    {
        FirstName = firstName;
        EmployeValidate.IsNameNotNull(firstName);
    }

    private void LastNameSet(string lastName)
    {
        LastName = lastName;
        EmployeValidate.IsLastNotNull(lastName);
    }

    private void EmailSet(string email)
    {
        Email = email;
        EmailValidator.IsValid(email);
    }
    private void PasswordSet(string password)
    {
        Password = password;
        FormatPassword.IsValidPassword(password);
    }

    private void PhoneNumberSet(string phoneNumber)
    {
        PhoneNumber = phoneNumber;
        EmployeValidate.IsPhoneNumberNotNull(phoneNumber);
    }

    private void AddressesSet(List<Addresses> addresses){
        Addresses = addresses;
        
    }
}


