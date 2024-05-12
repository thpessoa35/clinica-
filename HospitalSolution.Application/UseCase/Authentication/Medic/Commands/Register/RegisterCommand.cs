using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace HospitalSolution.Application.UseCase.Authentication.Medics.Commands.Register;

public record RegisterCommand(
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
    ): IRequest<AuthenticationMedicResult>;

public record RegisterAddressRequest(
    string? Id,
    string Address,
    string City,
    string State,
    string ZipCode,
    int Number
);




