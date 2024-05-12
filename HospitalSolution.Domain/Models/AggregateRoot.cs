using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalSolution.Domain.Models;

public abstract class AggregateRoot<TId> : Entity<TId> where TId : notnull
{
    public AggregateRoot(TId id) : base(id)
    {
    }
}