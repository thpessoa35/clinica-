using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalSolution.Application.UseCase.Authentication.Pacient.Commands;
using HospitalSolution.Contracts.Authentication.Pacient;

namespace HospitalSolution.Api.Mapping.Pacient.Register
{
    public static class MappingRequest
    {
        public static RegisterCommandPacient MapperRequest(RegisterPacientRequest request)
        {
            return new RegisterCommandPacient(
                request.Id.ToString(),
                request.FisrtName,
                request.LastName,
                request.TypeBlood,
                request.Cpf,
                request.PhoneNumber,
                request.Addresses.Select(address => new RegisterAddresses(address.Address, address.City, address.State, address.ZipCode, address.Number)).ToList(),
                request.Created,
                request.Updated
            );
        }
    }
}