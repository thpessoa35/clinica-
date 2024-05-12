
using HospitalSolution.Domain.Appointment;
using MediatR;

namespace HospitalSolution.Application.UseCase.appointment.Queries.GetManyAppointmentByIdMedic;

public record GetMedicIdCommand(
    string MedicId
): IRequest<IEnumerable<Appointment>>;
