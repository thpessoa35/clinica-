using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using appointmentsResult;
using HospitalSolution.Domain.Appointment.valueObject;
using MediatR;

namespace HospitalSolution.Application.UseCase.appointment.Queries;

public record GetCommand(
     string id
): IRequest<AppointmentsResult>;
