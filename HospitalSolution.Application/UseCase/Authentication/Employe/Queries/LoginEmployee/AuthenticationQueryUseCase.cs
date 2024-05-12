using employe;
using HospitalSolution.Application.Common.Interfaces.Authentication;
using HospitalSolution.Application.UseCase.Authentication.Common;
using HospitalSolution.Domain.Entities;
using HospitalSolution.Infrastructure.Persistence;
using MediatR;

namespace HospitalSolution.Application.UseCase.Authentication.Queries.LoginEmployee;


public class AuthenticationQueryUseCase : IRequestHandler<LoginCommand, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IEmployeRepository _employeRepository;

    public AuthenticationQueryUseCase(IJwtTokenGenerator jwtTokenGenerator, IEmployeRepository employeRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _employeRepository = employeRepository;
    }

    public async Task<AuthenticationResult> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
            return default;
    }


}
