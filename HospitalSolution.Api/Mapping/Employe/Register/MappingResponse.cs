
using HospitalSolution.Application.UseCase.Authentication.Common;
using HospitalSolution.Contracts.Authentication.Employee;

namespace HospitalSolution.Api.Mapping.Employe.Register;

    public static class MappingResponse
    {
        public static AuthenticationResponse MapperResponse(AuthenticationResult result){
            return new AuthenticationResponse(

                result.Employe.Id.Id,
                result.Employe.FirstName,
                result.Employe.LastName,
                result.Employe.Email,
                result.Employe.PhoneNumber,
                result.Employe.Addresses.ConvertAll(e => new AddressesEmployee(e.Id, e.Address, e.City, e.State, e.ZipCode, e.Number)).ToList(),
                result.Token    

            );
        }
    }
