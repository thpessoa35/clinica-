
using HospitalSolution.Application.Common.Persistence;
using HospitalSolution.Application.UseCase.Authentication.Common;
using HospitalSolution.Application.UseCase.Authentication.Pacient.Commands.Update;
using MediatR;


namespace pdateCommandHandler;

public class UpdateCommandHandler : IRequestHandler<UpdateCommandPacient, AuthenticationResultPacient>
{
    private readonly IPacientRepository _pacientRepository;

    public UpdateCommandHandler(IPacientRepository pacientRepository)
    {
        _pacientRepository = pacientRepository;
    }

    public async Task<AuthenticationResultPacient> Handle(UpdateCommandPacient request, CancellationToken cancellationToken)
    {
        var existingPacient = await _pacientRepository.FindById(request.Id);

        if (existingPacient != null)
        {

            foreach (var address in existingPacient.Enderecos)
            {
                var putAddress = request.Addresses.FirstOrDefault(x => x.Id == address.Id);

                if (putAddress != null) { address.Put(putAddress.Address, putAddress.State, putAddress.City, putAddress.ZipCode, putAddress.Number); }

            };
            existingPacient.Put(request.FirstName, request.LastName, request.Cpf, request.PhoneNumber, request.TypeBlood, existingPacient.Enderecos);
        }
        await _pacientRepository.Updated(request.Id, existingPacient);

        return new AuthenticationResultPacient(existingPacient);
    }
}