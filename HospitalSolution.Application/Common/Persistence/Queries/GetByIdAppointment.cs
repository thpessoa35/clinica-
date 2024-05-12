
using HospitalSolution.Domain.Appointment;
using HospitalSolution.Domain.Appointment.valueObject;

namespace HospitalSolution.Application.Common.Persistence.Queries;

public interface IGetByIdAppointment
{
    Task<Appointment?> GetById(string Id);
    Task<IEnumerable<Appointment>> GetManyAppointmentByIdMedic(string MedicId);
    Task<IEnumerable<Appointment>> GetDateAppointment(DateTime date);
}
