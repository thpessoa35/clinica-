using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalSolution.Domain.Appointment;

namespace HospitalSolution.Application.Common.Persistence;

public interface IAppointmentRepository
{
    Task Add(Appointment appointment);
}
