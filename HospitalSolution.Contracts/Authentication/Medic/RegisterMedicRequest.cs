namespace HospitalSolution.Contracts.Authentication.Medic;

public record RegisterMedicRequest(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    int CRMNumber,
    string Specialty,
    string? HospitalAffiliation,
    string PhoneNumber,
    List<RegisterAddressRequest> Address,
    DateTime Created,
    DateTime Updated
);

public record RegisterAddressRequest(
    string? Id,
    string Address,
    string City,
    string State,
    string ZipCode,
    int Number
);
