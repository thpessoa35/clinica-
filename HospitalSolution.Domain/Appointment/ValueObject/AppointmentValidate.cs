
using HospitalSolution.Domain.entities.Pacient;
using HospitalSolution.Domain.Entities.medic;

namespace HospitalSolution.Domain.Appointment.valueObject;

public static class AppointmentValidate
{
    internal static void DescripitonValidation(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentException("Description cannot be null or empty.", nameof(description));
        }
    }
    internal static void StatusValitadion(string status)
    {

        if (string.IsNullOrWhiteSpace(status))
        {
            throw new ArgumentException("Status cannot be null or empty.", nameof(status));
        }
    }

    internal static void PacienteValidation(PacientId pacient)
    {
        if (pacient.Id.ToString() == "")
        {
            throw new ArgumentException("Pacient cannot be null.", nameof(pacient));
        }
    }
    internal static void MedicValidation(MedicId medic)
    {
        if (medic.Id.ToString() == "")
        {
            throw new ArgumentException("Medic cannot be null.", nameof(medic));
        }
    }
    internal static void DateValidation(AgendAppointment date)
    {
        if (date.ConsultationDateTime.Date == default && date.ToString() == "")
        {
             throw new ArgumentException("Date cannot be null.", nameof(date));
        }
    }
}
