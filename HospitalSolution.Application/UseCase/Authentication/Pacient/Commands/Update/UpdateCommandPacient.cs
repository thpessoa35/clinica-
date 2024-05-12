using HospitalSolution.Application.UseCase.Authentication.Common;
using MediatR;


namespace HospitalSolution.Application.UseCase.Authentication.Pacient.Commands.Update;

public record UpdateCommandPacient
(
     string Id,
     string? FirstName,
     string? LastName,
     string? TypeBlood,
     string? Cpf,
     string? PhoneNumber,
     List<RegisterAddresses>? Addresses
):IRequest<AuthenticationResultPacient>;

public record RegisterAddresses(
    string? Id,
    string? Address,
    string? City,
    string? State,
    string? ZipCode,
    int Number
);