using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalSolution.Contracts.Appointments;

public record RegisterAppointmentRequest
(
    string Status,
    string Description,
    string IdMedic,
    string IdPacient,
    DateTime Date
);

