namespace Dotify.Core.Shared;

public abstract class Entity<T>
{
    public virtual T Id { get; set; }

    protected Entity(T id)
    {
        Id = id;
    }
}
