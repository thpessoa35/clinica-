
using HospitalSolution.Application.UseCase.Authentication.Common;

using MediatR;

namespace HospitalSolution.Application.UseCase.Authentication.Pacient.Commands;

public record RegisterCommandPacient(
    string Id,
     string FirstName,
     string LastName,
     string TypeBlood,
     string Cpf,
     string PhoneNumber,
     List<RegisterAddresses> Addresses,
     DateTime Created,
     DateTime Upadate

) : IRequest<AuthenticationResultPacient>;


public record RegisterAddresses(
    
    string Address,
    string City,
    string State,
    string ZipCode,
    int Number
);
