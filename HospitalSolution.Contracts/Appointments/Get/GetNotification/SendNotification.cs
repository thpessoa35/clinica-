using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalSolution.Contracts.appointments.Get.GetNotification;

public record SendNotification
(
    string Id,
    string Status,
    string Description,
    DateTime Date,
    List<Medic> Medic,
    List<Paciente> Pacient

);

public record Paciente(
    string Id,
    string FirstName,
    string LastName,
    string PhoneNumber
);

public record Medic(
    string Id,
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber
);



