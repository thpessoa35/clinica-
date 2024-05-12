using HospitalSolution.Application.UseCase.Authentication.Medics.Commands.Register;
using HospitalSolution.Domain.Entities.Medic;

using HospitalSolution.Infrastructure.Persistence;
using MediatR;


namespace HospitalSolution.Application.UseCase.Authentication.Medics.Commands
{
    public class RegisterMedicCommandHandler : IRequestHandler<RegisterCommand, AuthenticationMedicResult>
    {

        private readonly IMedicRepository _medicRepository;

        public RegisterMedicCommandHandler(IMedicRepository medicRepository)
        {
            _medicRepository = medicRepository;
        }

        public async Task<AuthenticationMedicResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {


            var medic = Medic.Create(
                firstName: request.FirstName,
                lastName: request.LastName,
                email: request.Email,
                password: request.Password,
                crmNumber: request.CRMNumber,
                specialty: request.Specialty,
                hospitalAffiliation: request.HospitalAffiliation,
                phoneNumber: request.PhoneNumber,
                addresses: request.Address.ConvertAll(address => MedicAddress.Create(
                    address.Address,
                    address.State,
                    address.City,
                    address.ZipCode,
                    address.Number
                    ))
                );

            await _medicRepository.Add(medic);

            return await Task.FromResult(new AuthenticationMedicResult(medic));
        }
    }
}
