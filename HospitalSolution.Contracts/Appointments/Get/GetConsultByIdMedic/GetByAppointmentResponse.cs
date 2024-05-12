

namespace HospitalSolution.Contracts.Appointments.Get.GetConsultByIdMedic;

public record GetByAppointmentResponse(
    string Id, 
    string Status, 
    string Description,
    List<Medic> Medic,
    List<Pacient> Pacient,
    DateTime Date
);


public record Medic(
    string Id,
    string FirstName,
    string lastName,
    string phoneNumber
);

public record Pacient(
    string Id,
     string FirstName,
     string LastName,
     string TypeBlood,
     string Cpf,
     string PhoneNumber,
     List<Addresses> Addresses,
     DateTime Created,
     DateTime Upadate

);

public record Addresses(
    string Address,
    string City,
    string State,
    string ZipCode,
    int Number
 );





