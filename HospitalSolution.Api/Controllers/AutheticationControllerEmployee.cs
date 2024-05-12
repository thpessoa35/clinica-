

using HospitalSolution.Api.Mapping.Employe;
using HospitalSolution.Api.Mapping.Employe.Register;

using HospitalSolution.Contracts.Authentication.Employee;
using MediatR;

using Microsoft.AspNetCore.Mvc;
namespace HospitalSolution.Api.Controllers;

[ApiController]
[Route("auth")]
public class AutheticationControllerEmployee : ControllerBase
{
    private readonly IMediator _mediator;
    public AutheticationControllerEmployee(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterEmployeeRequest request)
    {

        var register = MappingRequest.MapperRequest(request);

        var result = await _mediator.Send(register);

        var response = MappingResponse.MapperResponse(result);
        return Ok(response);
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginEmployeeRequest loginRequest)
    {
        var login = MappingLoginRequest.MapperRequest(loginRequest);

        var result = await _mediator.Send(login);

        return Ok(result);

    }

}

