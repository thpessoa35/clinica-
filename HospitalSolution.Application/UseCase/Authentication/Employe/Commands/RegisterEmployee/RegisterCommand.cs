
using HospitalSolution.Application.UseCase.Authentication.Common;
using MediatR;

namespace HospitalSolution.Application.UseCase.Authentication.Commands;

public record RegisterCommand
(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string PhoneNumber,
    List<AddressesCommand> Addresses
) : IRequest<AuthenticationResult>;

public record AddressesCommand (
    string Address,
    string City,
    string State,
    string ZipCode,
    int Number
);
