
using HospitalSolution.Api.Mapping.appointment.Get;
using HospitalSolution.Api.Mapping.Appointment.Register;
using HospitalSolution.Application.UseCase.appointment.Queries;
using HospitalSolution.Application.UseCase.appointment.Queries.GetByDateAppoinment;
using HospitalSolution.Application.UseCase.appointment.Queries.GetManyAppointmentByIdMedic;
using HospitalSolution.Contracts.Appointments;
using HospitalSolution.Contracts.Appointments.Get.GetConsultByIdMedic;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HospitalSolution.Api.Controllers
{
    [ApiController]
    [Route("appointments")]
    public class AppoinmentsController : ControllerBase
    {

        private readonly IMediator _mediator;


        public AppoinmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("register")]

        public async Task<IActionResult> Create(RegisterAppointmentRequest request)
        {
            var register = MappingAppoinmentRequest.MapperRequest(request);

            var send = await _mediator.Send(register);

            return Ok(send);
        }

        [HttpGet]

        [Route("{id}")]

        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var getId = new GetCommand(id);

            var send = await _mediator.Send(getId);

            var response = MappingAppointmentResponse.MapperResponse(send);

            return Ok(response);
        }

        [HttpGet]
        [Route("medic/{id}")]
        public async Task<IActionResult> GetManyAppointments([FromRoute] string id)
        {
            var getId = new GetMedicIdCommand(id.ToString());

            var send = await _mediator.Send(getId);

            var response = GetByAppointmentResponseMapper.MapFrom(send);

            return Ok(response);
        }

        [HttpGet]

        public async Task<IActionResult> GetBydate([FromQuery] DateTime date)
        {

            var Data = new GetDateCommand(date);

            var send = await _mediator.Send(Data);

            var response = GetAgendAppointmentMapping.MapperResponse(send);

            return Ok(response);
        }

    }
}