

namespace HospitalSolution.Domain.Models;

public abstract class Entity<TId>: IEquatable<Entity<TId>> where TId : notnull
{
    public TId Id { get; protected set; }   

    protected Entity(TId id)
    {
        Id = id;
    }

    public override bool Equals(object? obj)
    {
        return obj is Entity<TId> entity && Equals(entity);
    }

    public bool Equals(Entity<TId>? other)
    {
        return Equals((object?)other);
    }

    public static bool operator ==(Entity<TId> left, Entity<TId> rigth)
    {
        return Equals(left, rigth);
    }
    public static bool operator !=(Entity<TId> left, Entity<TId> rigth)
    {
        return !Equals(left, rigth);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
