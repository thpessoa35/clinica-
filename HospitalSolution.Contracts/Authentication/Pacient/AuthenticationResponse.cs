
using HospitalSolution.Contracts.Authentication.Pacient;

namespace authenticationResponse;

public record AuthenticationResponse
(
    string Id,
    string FisrtName,
    string LastName,
    string TypeBlood,
    string Cpf,
    string PhoneNumber,
    List<Addresses> Addresses,
    DateTime Created,
    DateTime Updated
);


