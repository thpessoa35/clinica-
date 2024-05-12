using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using appointmentsResult;
using HospitalSolution.Domain.entities.Pacient;
using HospitalSolution.Domain.Entities.medic;
using MediatR;

namespace HospitalSolution.Application.UseCase.Appointments.Commands.Create;

public record RegisterCommand(
    string Status,
    string Description,
    MedicId Medic,
    PacientId Pacient,
    DateTime Date
) : IRequest<AppointmentsResult>;





