using findByIdComand;
using HospitalSolution.Api.Mapping;
using HospitalSolution.Application.UseCase.Authentication.medic.Queries.FindALL;
using HospitalSolution.Contracts.Authentication.Medic;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace HospitalSolution.Api.Controllers
{
    [ApiController]
    [Route("auth/medic")]
    public class AuthenticationControllerMedic : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthenticationControllerMedic(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterMedicRequest request)
        {
            try
            {
                var command = MappingMedicRequest.MapperRequest(request);

                var result = await _mediator.Send(command);

                var response = MappingMedicResponse.MapperResponse(result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet]

        public async Task<ActionResult> Get()
        {
            var command = new FindALLCommand();

            var result = await _mediator.Send(command);

            var response = result.Select(medic =>
         new AuthenticationMedicResponse(
             medic.Id.Id.ToString(),
             medic.FirstName,
             medic.LastName,
             medic.Email,
             medic.CRMNumber,
             medic.Specialty,
             medic.HospitalAffiliation,
             medic.PhoneNumber,
             medic.Addresses.Select(address => new RegisterAddressRequest(address.Id, address.Address, address.State, address.City, address.ZipCode, address.Number)).ToList(),
             medic.Created,
             medic.Updated
         )).ToList();

            return Ok(response);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult> GetById(string id)
        {
            var command = new FindByIdComand(id);

            var send = await _mediator.Send(command);

            return Ok(send);
        }

    }
}
