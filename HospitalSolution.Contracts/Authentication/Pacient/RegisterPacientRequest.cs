using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalSolution.Contracts.Authentication.Pacient;

public record RegisterPacientRequest(

    Guid Id,
    string FisrtName,
    string LastName,
    string TypeBlood,
    string Cpf,
    string PhoneNumber,
    List<Addresses> Addresses,
    DateTime Created,
    DateTime Updated
);

public record Addresses(
    string? Id,
    string Address,
    string City,
    string State,
    string ZipCode,
    int Number
);





