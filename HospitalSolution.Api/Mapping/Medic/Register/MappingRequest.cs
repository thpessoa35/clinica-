
using HospitalSolution.Application.UseCase.Authentication.Medics.Commands.Register;
using HospitalSolution.Contracts.Authentication.Medic;

namespace HospitalSolution.Api.Mapping
{
    public static class MappingMedicRequest
    {
        public static RegisterCommand MapperRequest(RegisterMedicRequest request)
        {
            return new RegisterCommand(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password,
                request.CRMNumber,
                request.Specialty,
                request.HospitalAffiliation,
                request.PhoneNumber,
                request.Address.Select(a => new Application.UseCase.Authentication.Medics.Commands.Register.RegisterAddressRequest(a.Id, a.Address, a.City, a.State, a.ZipCode, a.Number)).ToList(),
                request.Created,
                request.Updated
            );
        }
    }
}
