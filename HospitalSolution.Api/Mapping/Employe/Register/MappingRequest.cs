

using HospitalSolution.Application.UseCase.Authentication.Commands;
using HospitalSolution.Contracts.Authentication.Employee;

namespace HospitalSolution.Api.Mapping.Employe.Register
{
    public static class MappingRequest
    {
        public static RegisterCommand MapperRequest(RegisterEmployeeRequest register)
        {

            return new RegisterCommand(
                    register.Id,
                    register.FirstName,
                    register.LastName,
                    register.Email,
                    register.Password,
                    register.PhoneNumber,
                    register.Addresses.Select(e => new AddressesCommand(e.Address, e.City, e.State, e.ZipCode, e.Number)).ToList()
            );
        }
    }
}