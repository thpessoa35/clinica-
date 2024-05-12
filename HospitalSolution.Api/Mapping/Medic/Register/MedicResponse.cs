
using HospitalSolution.Contracts.Authentication.Medic;

using RegisterAddressRequest = HospitalSolution.Contracts.Authentication.Medic.RegisterAddressRequest;

namespace HospitalSolution.Api.Controllers
{
    public static  class MappingMedicResponse
    {
        public static AuthenticationMedicResponse MapperResponse(AuthenticationMedicResult result)
        {
            return new AuthenticationMedicResponse(
                Id: result.Medic.Id.Id,
                FirstName: result.Medic.FirstName,
                LastName: result.Medic.LastName,
                Email: result.Medic.Email,
                CRMNumber: result.Medic.CRMNumber,
                Specialty: result.Medic.Specialty,
                HospitalAffiliation: result.Medic.HospitalAffiliation,
                PhoneNumber: result.Medic.PhoneNumber,
                Address: result.Medic.Addresses.Select(a => new RegisterAddressRequest(a.Id, a.Address, a.City, a.State, a.ZipCode, a.Number)).ToList(),
                Created: result.Medic.Created,
                Updated: result.Medic.Updated
            );
        }
    }
}
