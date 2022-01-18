namespace Dotify.Core.Shared;

public abstract class BaseEntity<T>
{
#nullable disable warnings
    public virtual T Id { get; protected set; }
}
