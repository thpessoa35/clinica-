using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using appointmentsResult;
using HospitalSolution.Contracts.Appointments;
using HospitalSolution.Domain.entities.Pacient;
using HospitalSolution.Domain.Entities.medic;

namespace HospitalSolution.Api.Mapping.Appointment.Register;

public static class MappingAppointmentResponse
{
    public static RegisterAppointmentResponse MapperResponse(AppointmentsResult response)
    {
        MedicId medicId = MedicId.GetId(response.Appointment.MedicId.Id);
        PacientId pacientId = PacientId.GetId(response.Appointment.PacientId.Id);
        return new RegisterAppointmentResponse
        (
            response.Appointment.Id.Id,
            response.Appointment.Status,
            response.Appointment.Description,
            pacientId.ToString(),
            medicId.ToString(),
            response.Appointment.Date
        );
    }
}