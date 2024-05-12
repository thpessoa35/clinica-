
using HospitalSolution.Domain.Models;

namespace HospitalSolution.Domain.Appointment.valueObject;

public class AppointmentId : ValueObject
{

    public string Id { get; }
    private AppointmentId(string id)
    {
        Id = id;
    }
    public static AppointmentId CreateUnique()
    {
        string id = Guid.NewGuid().ToString();
        return new(id);
    }
    public static AppointmentId GetId(string id)
    {
        return new AppointmentId(id);
    }

    public override IEnumerable<object> GetEqualsComponets()
    {
        yield return Id;
    }
}
