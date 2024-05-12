
using HospitalSolution.Domain.Appointment.valueObject;
using HospitalSolution.Domain.entities.Pacient;
using HospitalSolution.Domain.Entities.medic;
using HospitalSolution.Domain.Entities.Medic;
using HospitalSolution.Domain.Models;
using pacient;


namespace HospitalSolution.Domain.Appointment;

public sealed class Appointment : AggregateRoot<AppointmentId>
{

    public string Status { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public string Priority { get; private set; } = string.Empty;
    public MedicId MedicId { get; set; }
    public PacientId PacientId { get; set; }
    public DateTime Date { get;  set; }
    public Medic Medic { get; set; }
    public Paciente Pacient { get; set; }
    private Appointment() : base(default) { }

    private Appointment(AppointmentId id, MedicId medic, PacientId pacient, string status, string description, DateTime date) : base(id)
    {
        MedicIdSet(medic);
        PacienteIdSet(pacient);
        StatusSet(status);
        DescripitonSet(description);
        DateSet(date);
    }

    public static Appointment Create(MedicId medic, PacientId pacient, string status, string description, DateTime date)
    {
        return new(AppointmentId.CreateUnique(), medic, pacient, status, description, date);
    }

    private void MedicIdSet(MedicId medic)
    {
        MedicId = medic;
        AppointmentValidate.MedicValidation(MedicId);
    }
    private void DateSet(DateTime date)
    {
        Date = date;
    }
    private void StatusSet(string status)
    {
        Status = status;
        AppointmentValidate.StatusValitadion(status);

    }

    private void DescripitonSet(string description)
    {
        Description = description;
        AppointmentValidate.DescripitonValidation(Description);

    }
    private void PacienteIdSet(PacientId pacient)
    {
        PacientId = pacient;
        AppointmentValidate.PacienteValidation(pacient);
    }
}
