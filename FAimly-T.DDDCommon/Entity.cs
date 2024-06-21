using Newtonsoft.Json;

namespace FaimlyT.Common.DDD.BaseObjects;

public abstract class Entity<TId> : IEntity, IEquatable<Entity<TId>>
{
    [JsonIgnore]
    public TId? Id { get; set; }

    [JsonIgnore]
    object? IEntity.Id
    {
        get => Id ?? throw new NullReferenceException("Id is null");
        set => Id = (TId?)value;
    }

    protected Entity() { }

    protected Entity(TId id)
    {
        if (id == null)
            throw new ArgumentNullException(nameof(id));
        Id = id;
    }

    public bool Equals(Entity<TId>? other)
    {
        return Equals((object?)other);
    }

    public override bool Equals(object? obj)
    {
        return obj is Entity<TId> entity &&
               Id.Equals(entity.Id);
    }

    public static bool operator ==(Entity<TId>? left, Entity<TId>? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Entity<TId>? left, Entity<TId>? right)
    {
        return !Equals(left, right);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}

public interface IEntity
{
    [JsonIgnore]
    object? Id { get; set; }
}