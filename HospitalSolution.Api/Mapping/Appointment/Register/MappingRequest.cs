
using HospitalSolution.Application.UseCase.Appointments.Commands.Create;
using HospitalSolution.Contracts.Appointments;
using HospitalSolution.Domain.entities.Pacient;
using HospitalSolution.Domain.Entities.medic;

namespace HospitalSolution.Api.Mapping.Appointment.Register;

public static class MappingAppoinmentRequest
{
    public static RegisterCommand MapperRequest(RegisterAppointmentRequest request)
    {
        MedicId medicId = MedicId.GetId(request.IdMedic.ToString());
        PacientId pacientId = PacientId.GetId(request.IdPacient);

        return new RegisterCommand(
            request.Status,
            request.Description,
            medicId,
            pacientId,
            request.Date
        );
    }
}