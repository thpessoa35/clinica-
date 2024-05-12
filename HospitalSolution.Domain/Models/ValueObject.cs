using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalSolution.Domain.Models;

public abstract class ValueObject: IEquatable<ValueObject>
{
    public abstract IEnumerable<object> GetEqualsComponets();

    public override bool Equals(object? obj)
    {
        if (obj == null || obj.GetType() != GetType()){
            return false;   
        }     

        var ValueObject = (ValueObject)obj;  

        return GetEqualsComponets().SequenceEqual(ValueObject.GetEqualsComponets());
    }
    public static bool operator ==(ValueObject left, ValueObject right)
    {
        return Equals(left, right);
    }
    public static bool operator !=(ValueObject left, ValueObject right)
    {
        return !Equals(right, left);
    }

    public override int GetHashCode(){
        return GetEqualsComponets().Select(x => x?.GetHashCode() ?? 0).Aggregate((x, y) => y ^ x);
    }
    public bool Equals(ValueObject? other)
    { 
        return Equals((object?)other);  
    }   
}
