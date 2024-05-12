
using HospitalSolution.Domain.Models;

namespace addressId;

public class AddressId : ValueObject
{
    public Guid IdAddress { get; set; }

    private AddressId(Guid idAddress)
    {
        IdAddress = idAddress;
    }

    public static AddressId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualsComponets()
    {
        yield return IdAddress;
    }
}
