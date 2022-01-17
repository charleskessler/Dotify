namespace Dotify.Core.Shared;

public interface ILocatableEntity
{
    string Href { get; }
    string Uri { get; }
    string Type { get; }
}
