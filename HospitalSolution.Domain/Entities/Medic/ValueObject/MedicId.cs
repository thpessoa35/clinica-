

using HospitalSolution.Domain.Models;

namespace HospitalSolution.Domain.Entities.medic;

public sealed class MedicId : ValueObject
{
    public string Id { get; set; }

    private MedicId(string id)
    {
        SetId(id);
    }

    public static MedicId CreateUnique()
    {
        string newId = Guid.NewGuid().ToString();
        return new(newId);
    }

    public void SetId(string id)
    {
        Id = id;
    }

    public static MedicId GetId(string id)
    {
        return new MedicId(id);
    }

    public override IEnumerable<object> GetEqualsComponets()
    {
        yield return Id;
    }
}

