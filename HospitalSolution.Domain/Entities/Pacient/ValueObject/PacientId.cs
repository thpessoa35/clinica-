
using HospitalSolution.Domain.Models;

namespace HospitalSolution.Domain.entities.Pacient;

public sealed class PacientId : ValueObject
{

    public string Id { get; }


    private PacientId(string id)
    {
        Id = id;
    }

    public static PacientId CreateUnique()
    {
        string Id = Guid.NewGuid().ToString();
        return new(Id);
    }

    public static PacientId GetId(string id){
        return new PacientId(id);
    }
    public override IEnumerable<object> GetEqualsComponets()
    {
        yield return Id;
    }
}
