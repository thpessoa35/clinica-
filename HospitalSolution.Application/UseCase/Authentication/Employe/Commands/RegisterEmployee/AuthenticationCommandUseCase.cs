
using addressesEmploye;
using addressId;
using employe;
using employeId;
using HospitalSolution.Application.Common.Interfaces.Authentication;
using HospitalSolution.Application.UseCase.Authentication.Common;
using HospitalSolution.Infrastructure.Persistence;
using MediatR;


namespace HospitalSolution.Application.UseCase.Authentication.Commands.RegisterEmployee;

public class AuthenticationCommandUseCase : IRequestHandler<RegisterCommand, AuthenticationResult>
{

    private readonly IEmployeRepository _employeRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationCommandUseCase(IEmployeRepository employeRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _employeRepository = employeRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<AuthenticationResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
     

        var result =  Employe.Create(
            firstName: request.FirstName,
            lastName: request.LastName,
            email: request.Email,
            password: request.Password,
            phoneNumber: request.PhoneNumber,
            addresses: request.Addresses.ConvertAll(e =>  Addresses.Create(e.Address, e.City, e.State, e.ZipCode, e.Number ))
        );
        await _employeRepository.Add(result);

        var token = _jwtTokenGenerator.GenerateToken(result);

         return await Task.FromResult(new AuthenticationResult(result, token));
    }
}




