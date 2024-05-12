

namespace HospitalSolution.Contracts.Authentication.Employee;

public record AuthenticationResponse(
    string Id,
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    List<AddressesEmployee> Addresses,
    string Token
 );



