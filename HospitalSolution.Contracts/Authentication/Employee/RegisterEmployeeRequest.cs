
namespace HospitalSolution.Contracts.Authentication.Employee;

public record RegisterEmployeeRequest(

    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string PhoneNumber,
    List<AddressesEmployee> Addresses
 );

public record AddressesEmployee(
   string? Id,
   string Address,
   string City,
   string State,
   string ZipCode,
   int Number
);



