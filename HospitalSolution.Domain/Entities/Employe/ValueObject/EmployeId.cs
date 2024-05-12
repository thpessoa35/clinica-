using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalSolution.Domain.Models;

namespace employeId;

public class EmployeId : ValueObject
{
    public string Id { get;}

    private EmployeId(string id)
    {
        Id = id;
    }

    public static EmployeId CreateUnique()
    {
       string uniqueId = Guid.NewGuid().ToString();
        return new(uniqueId);
    }

    public override IEnumerable<object> GetEqualsComponets()
    {
        yield return Id;
    }
}
