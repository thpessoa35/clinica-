
using HospitalSolution.Domain.Appointment;
using MediatR;

namespace HospitalSolution.Application.UseCase.appointment.Queries.GetByDateAppoinment;

public record GetDateCommand(DateTime Date):IRequest<IEnumerable<Appointment>>;