
using HospitalSolution.Api.Mapping.Pacient.Register;
using HospitalSolution.Application.UseCase.Authentication.Pacient.Commands;
using HospitalSolution.Application.UseCase.Authentication.Pacient.Commands.Update;
using HospitalSolution.Contracts.Authentication.Pacient;
using HospitalSolution.Domain.entities.Pacient;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HospitalSolution.Api.Controllers
{
    [ApiController]
    [Route("auth/pacient")]
    [Authorize]
    public class AuthenticationControllerPacient : ControllerBase
    {

        private readonly IMediator mediator;
        public AuthenticationControllerPacient(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Create(RegisterPacientRequest request)
        {

            var value = MappingRequest.MapperRequest(request);

            var send = await mediator.Send(value);

            var response = MappingResponse.MapperResponse(send);

            return Ok(response);

        }
        [HttpPut()]
        public async Task<ActionResult> Update([FromBody] UpdateCommandPacient command)
        {
           
            var request = new UpdateCommandPacient(
            command.Id,
            command.FirstName,
            command.LastName,
            command.TypeBlood,
            command.Cpf,
            command.PhoneNumber,
            command.Addresses
         );

            var send = await mediator.Send(request);

            return Ok(send);
        }
    }
}


