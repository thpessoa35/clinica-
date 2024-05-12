using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using authenticationResponse;
using HospitalSolution.Application.UseCase.Authentication.Common;
using HospitalSolution.Contracts.Authentication.Pacient;
using HospitalSolution.Domain.Entities.Address.Entities;

namespace HospitalSolution.Api.Mapping.Pacient.Register
{
    public static class MappingResponse
    {
        public static AuthenticationResponse MapperResponse(AuthenticationResultPacient response){
            return new AuthenticationResponse(
                response.Paciente.Id.Id,
                response.Paciente.FirstName,
                response.Paciente.LastName,
                response.Paciente.TypeBlood,
                response.Paciente.Cpf,
                response.Paciente.PhoneNumber,
                response.Paciente.Enderecos.Select(x => new Addresses(x.Id, x.Address, x.City, x.State, x.ZipCode, x.Number)).ToList(),
                response.Paciente.Created,
                response.Paciente.Updated
            );
        }
    }
}