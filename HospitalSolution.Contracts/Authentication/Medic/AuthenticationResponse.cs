namespace HospitalSolution.Contracts.Authentication.Medic;

public record AuthenticationMedicResponse(
    string Id,
    string FirstName,
    string LastName,
    string Email,
    int CRMNumber,
    string Specialty,
    string? HospitalAffiliation,
    string PhoneNumber,
    List<RegisterAddressRequest> Address,
    DateTime Created,
    DateTime Updated

);


