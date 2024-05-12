
using HospitalSolution.Application.Common.Persistence;
using HospitalSolution.Application.UseCase.Authentication.Common;
using HospitalSolution.Domain.Entities.Address.Entities;
using MediatR;
using pacient;

namespace HospitalSolution.Application.UseCase.Authentication.Pacient.Commands;

public class RegisterCommandHandler : IRequestHandler<RegisterCommandPacient, AuthenticationResultPacient>
{
    private readonly IPacientRepository _pacientRepository;

    public RegisterCommandHandler(IPacientRepository pacientRepository)
    {
        _pacientRepository = pacientRepository;
    }

    public async Task<AuthenticationResultPacient> Handle(RegisterCommandPacient request, CancellationToken cancellationToken)
    {

        var pacient = Paciente.Create(

            firstName: request.FirstName,
            lastName: request.LastName,
            typeBlood: request.TypeBlood,
            cpf: request.Cpf,
            phoneNumber: request.PhoneNumber,
            addresses: request.Addresses.ConvertAll(address => PacientAddress.Create(address.Address, address.City, address.State, address.ZipCode, address.Number))

        );

        await _pacientRepository.Add(pacient);

        return new AuthenticationResultPacient(pacient);
    }
}
