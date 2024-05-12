
using HospitalSolution.Contracts.appointments.Get.GetNotification;
using Medic = HospitalSolution.Contracts.appointments.Get.GetNotification.Medic;


namespace HospitalSolution.Api.Mapping.appointment.Get;

public static class GetAgendAppointmentMapping
{
    public static List<SendNotification> MapperResponse(IEnumerable<Domain.Appointment.Appointment> appointments)
    {

        var responses = new List<SendNotification>();
        foreach (var appointment in appointments)
        {
            var medics = new List<Medic>();
            var patients = new List<Paciente>();

            var existingMedic = medics.FirstOrDefault(m => m.Id == appointment.Medic.Id.Id);

            if (existingMedic == null)
            {
                medics.Add(new Medic(
                    appointment.Medic.Id.Id,
                    appointment.Medic.FirstName,
                    appointment.Medic.LastName,
                    appointment.Medic.Email,
                    appointment.Medic.PhoneNumber
                ));
            }


            if (appointment.Pacient != null)
            {


                patients.Add(new Paciente(
                    appointment.Pacient.Id.Id,
                    appointment.Pacient.FirstName,
                    appointment.Pacient.LastName,
                    appointment.Pacient.PhoneNumber
                ));

            }


            DateTime date = appointment.Date;
            var response = new SendNotification(
                appointment.Id.Id,
                appointment.Status,
                appointment.Description,
                date,
                medics,
                patients
            );

            responses.Add(response);
        }
        return responses;

    }
}


