using appointmentsResult;
using HospitalSolution.Application.Common.Persistence;
using HospitalSolution.Domain.Appointment;
using HospitalSolution.Domain.Appointment.valueObject;
using HospitalSolution.Domain.entities.Pacient;
using HospitalSolution.Domain.Entities.medic;
using HospitalSolution.Domain.Entities.Medic;
using MediatR;



namespace HospitalSolution.Application.UseCase.Appointments.Commands.Create
{
    public class RegisterAppointmentHandler : IRequestHandler<RegisterCommand, AppointmentsResult>
    {
        private readonly IAppointmentRepository _appointmentsRepository;

        public RegisterAppointmentHandler(IAppointmentRepository appointmentsRepository)
        {
            _appointmentsRepository = appointmentsRepository;
        }

        public async Task<AppointmentsResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var response = Appointment.Create(
                status: request.Status,
                description: request.Description,
                medic: MedicId.GetId(request.Medic.Id),
                pacient: PacientId.GetId(request.Pacient.Id),
                date: request.Date
            );

            await _appointmentsRepository.Add(response);
           
            return new AppointmentsResult(response);
        }
    }
}
