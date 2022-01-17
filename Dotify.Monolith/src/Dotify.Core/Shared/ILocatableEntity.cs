namespace Dotify.Core.Shared;

public interface ILocatableEntity : IEntity
{
    string Href { get; }
    string Uri { get; }
    string Type { get; }
}
